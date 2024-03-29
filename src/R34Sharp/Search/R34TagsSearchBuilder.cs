﻿using R34Sharp.Enums;

using System;

namespace R34Sharp.Search
{
    /// <summary>
    /// A search builder for Rule34 Tags.
    /// </summary>
    public sealed class R34TagsSearchBuilder
    {
        /// <summary>
        /// The type of search that will be performed on this browser.
        /// </summary>
        public R34TagSearchType SearchType { get; set; }

        /// <summary>
        /// The fetch value of the respective tag.
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// The limit of tags that will be returned.
        /// </summary>
        /// <remarks>
        /// The value must be between 1 and 100.
        /// </remarks>
        public int Limit
        {
            get => this._limit;
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The limit must be between 1 and 100.");
                }

                this._limit = value;
            }
        }

        private int _limit;

        /// <summary>
        /// Build a custom search for Rule34 Tags.
        /// </summary>
        public R34TagsSearchBuilder()
        {
            _ = WithSearchType(R34TagSearchType.Name);
            _ = WithSearch(string.Empty);
            _ = WithLimit(100);
        }

        /// <summary>
        /// Set the search type.
        /// </summary>
        /// <param name="value">The search type.</param>
        /// <returns>This search builder.</returns>
        public R34TagsSearchBuilder WithSearchType(R34TagSearchType value)
        {
            this.SearchType = value;
            return this;
        }

        /// <summary>
        /// Set the search value.
        /// </summary>
        /// <param name="value">The search value.</param>
        /// <returns>This search builder.</returns>
        public R34TagsSearchBuilder WithSearch(string value)
        {
            this.Search = value;
            return this;
        }

        /// <summary>
        /// Set the serach limite.
        /// </summary>
        /// <param name="value">The serach limite.</param>
        /// <returns>This search builder.</returns>
        public R34TagsSearchBuilder WithLimit(int value)
        {
            this.Limit = value;
            return this;
        }
    }
}
