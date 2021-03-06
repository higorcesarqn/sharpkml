﻿// Copyright (c) Samuel Cragg.
//
// Licensed under the MIT license. See LICENSE file in the project root for
// full license information.

namespace SharpKml.Dom
{
    using System.Collections.Generic;
    using SharpKml.Base;

    /// <summary>
    /// Specifies how a <see cref="Feature"/> is displayed in the list view.
    /// </summary>
    /// <remarks>OGC KML 2.2 Section 12.13.</remarks>
    [KmlElement("ListStyle")]
    public class ListStyle : SubStyle
    {
        /// <summary>
        /// The default value that should be used for <see cref="MaximumSnippetLines"/>.
        /// </summary>
        public const int DefaultMaximumSnippetLines = 2;

        /// <summary>
        /// The default value that should be used for <see cref="BackgroundColor"/>.
        /// </summary>
        public static readonly Color32 DefaultBackgroundColor = new Color32(255, 255, 255, 255);

        private readonly List<ItemIcon> icons = new List<ItemIcon>();

        /// <summary>
        /// Gets or sets the background color of the graphic element.
        /// </summary>
        [KmlElement("bgColor", 2)]
        public Color32? BackgroundColor { get; set; }

        /// <summary>
        /// Gets the <see cref="ItemIcon"/>s contained by this instance.
        /// </summary>
        [KmlElement(null, 3)]
        public IReadOnlyCollection<ItemIcon> ItemIcons => this.icons;

        /// <summary>
        /// Gets or sets how a <see cref="Folder"/> and its contents shall be
        /// displayed as items in the list view.
        /// </summary>
        [KmlElement("listItemType", 1)]
        public ListItemType? ItemType { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of lines to display for the
        /// <see cref="Feature.Snippet"/> value in the list view.
        /// </summary>
        [KmlElement("maxSnippetLines", 4)]
        public int? MaximumSnippetLines { get; set; }

        /// <summary>
        /// Adds the specified <see cref="ItemIcon"/> to this instance.
        /// </summary>
        /// <param name="icon">The <c>ItemIcon</c> to add to this instance.</param>
        /// <exception cref="System.ArgumentNullException">icon is null.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// icon belongs to another <see cref="Element"/>.
        /// </exception>
        public void AddItemIcon(ItemIcon icon)
        {
            this.AddAsChild(this.icons, icon);
        }
    }
}
