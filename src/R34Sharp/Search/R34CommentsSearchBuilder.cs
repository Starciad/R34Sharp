﻿namespace R34Sharp
{
    /// <summary>
    /// A search builder for Rule34 post comments.
    /// </summary>
    public class R34CommentsSearchBuilder
    {
        /// <summary>
        /// The ID of the post.
        /// </summary>
        public required ulong PostId { get; set; }

        /// <summary>
        /// Build a custom search for Rule34 post comments.
        /// </summary>
        public R34CommentsSearchBuilder()
        {
            WithId(0);
        }

        /// <summary>
        /// Set the Comment Id.
        /// </summary>
        /// <param name="value">The comment Id value.</param>
        /// <returns>This search builder.</returns>
        public R34CommentsSearchBuilder WithId(ulong value)
        {
            PostId = value;
            return this;
        }
    }
}
