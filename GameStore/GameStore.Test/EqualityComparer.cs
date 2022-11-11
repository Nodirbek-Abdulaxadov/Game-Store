using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Test
{
    internal class CommentEqualityComparer : IEqualityComparer<Comment>
    {
        public bool Equals([AllowNull] Comment? x, [AllowNull] Comment? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id &&
                   x.Body == y.Body &&
                   x.IsEdited == y.IsEdited &&
                   x.IsDeleted == y.IsDeleted &&
                   x.UserId == y.UserId &&
                   x.RepliedCommentId == y.RepliedCommentId &&
                   x.CommentedTime == y.CommentedTime &&
                   x.GameId == y.GameId;
        }

        public int GetHashCode([DisallowNull] Comment obj)
        {
            return obj.GetHashCode();
        }
    }
}
