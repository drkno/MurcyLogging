using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agilefantasy;
using MurcyLogging.Agilefant;

namespace MurcyLogging
{
    public enum Tag
    {
        Implement,
        Document,
        Test,
        TestManual,
        Fix,
        Chore,
        Refactor,
        Pair,
        Commits,
        Detail
    }

    public class AgilefantDesciption
    {
        public List<IAgilefantTag> Tags { get; private set; }

        private MultiTag commitsTag;
        private MultiTag pairTag;

        public AgilefantDesciption()
        {
            Tags = new List<IAgilefantTag>();
        }

        public void AddCommit(object commit)
        {
            if (commitsTag == null)
            {
                commitsTag = new MultiTag() { Tag = Tag.Commits };
                Tags.Add(commitsTag);
            }

            //TODO make sure we're actually getting the commit number here
            commitsTag.AddInfo(commit);
        }

        public void RemovePair(AgilefantUser user)
        {
            if (pairTag == null) return;

            pairTag.RemoveInfo(user.LoginName);

            if (pairTag.InfoPieces.Count == 0)
            {
                Tags.Remove(pairTag);
                pairTag = null;
            }
        }

        public void AddPair(AgilefantUser user)
        {
            if (pairTag == null)
            {
                pairTag = new MultiTag() { Tag = Tag.Pair };
                Tags.Add(pairTag);
            }

            pairTag.AddInfo(user.LoginName);
        }

        public void RemoveCommit(object commit)
        {
            if (commitsTag == null) return;

            //Make sure we're actually using the commit number here
            commitsTag.RemoveInfo(commit);

            if (commitsTag.InfoPieces.Count == 0)
            {
                Tags.Remove(commitsTag);
                commitsTag = null;
            }
        }

        public AgilefantDesciption AddTag(Tag type, string description)
        {
            if (type == Tag.Commits || type == Tag.Pair)
                throw new InvalidOperationException("The tag type '" + type + "' is special in that it needs some extra data. Use the AddPair or AddCommit methods");
            
            if (HasTag(type)) throw new InvalidOperationException("The description already has a '" + type + "' tag!");

            var tag = new BasicTag(){Tag = type, Content = description};
            Tags.Add(tag);

            return this;
        }

        public bool HasTag(Tag type)
        {
            return Tags.Any(t => t.Tag == type);
        }

        public static AgilefantDesciption New()
        {
            return new AgilefantDesciption();
        }

        public AgilefantDesciption WithPair(AgilefantUser user)
        {
            AddPair(user);
            return this;
        }

        public AgilefantDesciption WithCommit(object commit)
        {
            AddCommit(commit);
            return this;
        }

        public AgilefantDesciption WithDetail(string detail)
        {
            return AddTag(Tag.Detail, detail);
        }

        public AgilefantDesciption WithTest(string testDetail)
        {
            return AddTag(Tag.Test, testDetail);
        }

        public AgilefantDesciption WithTestManual(string testManualDetail)
        {
            return AddTag(Tag.TestManual, testManualDetail);
        }

        public AgilefantDesciption WithImplement(string implementsDetail)
        {
            return AddTag(Tag.Implement, implementsDetail);
        }

        public AgilefantDesciption WithRefactor(string refactorDetail)
        {
            return AddTag(Tag.Refactor, refactorDetail);
        }

        public AgilefantDesciption WithChore(string choreDetail)
        {
            return AddTag(Tag.Chore, choreDetail);
        }

        public AgilefantDesciption WithDocument(string documentDetail)
        {
            return AddTag(Tag.Document, documentDetail);
        }

        public AgilefantDesciption WithFix(string fixDetail)
        {
            return AddTag(Tag.Fix, fixDetail);
        }

        public string Build()
        {
            var builder = new StringBuilder(1000);
            foreach (var tag in Tags)
            {
                if (builder.Length != 0)
                    builder.Append(" ");

                builder.Append(tag.Serialize());
            }
            return builder.ToString();
        }
    }
}
