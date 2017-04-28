﻿//======================================================================
//
//        Copyright © 2017 NetInfo Technologies Ltd.
//        All rights reserved
//        guid1:                    8def1eda-60a6-4b7a-a519-b4d98e5db88d
//        CLR Version:              4.0.30319.42000
//        Name:                     ApplicationMenu
//        Computer:                 CHARLEY-PC
//        Organization:             NetInfo
//        Namespace:                NetInfo.Ribbon
//        File Name:                ApplicationMenu
//
//        Created by Charley at 2017/4/10 19:02:48
//        http://www.netinfo.com 
//
//======================================================================

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;


namespace NetInfo.Ribbon
{
    /// <summary>
    /// Extracts right content presenter of application menu converter
    /// </summary>
    public class ApplicationMenuRightContentExtractorConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ApplicationMenu menu = value as ApplicationMenu;
            if (menu != null) return menu.Template.FindName("PART_RightContentPresenter", menu) as ContentPresenter;
            return value;
        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param><param name="targetType">The type to convert to.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion
    }

    /// <summary>
    /// Represents backstage button
    /// </summary>
    public class ApplicationMenu : DropDownButton
    {
        #region Fields



        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets width of right content
        /// </summary>
        public double RightPaneWidth
        {
            get { return (double)GetValue(RightPaneWidthProperty); }
            set { SetValue(RightPaneWidthProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for RightContentWidth.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty RightPaneWidthProperty =
            DependencyProperty.Register("RightPaneWidth", typeof(double), typeof(ApplicationMenu), new UIPropertyMetadata(300.0));



        /// <summary>
        /// Gets or sets application menu right pane content
        /// </summary>
        public object RightPaneContent
        {
            get { return (object)GetValue(RightPaneContentProperty); }
            set { SetValue(RightPaneContentProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for RightContent.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty RightPaneContentProperty =
            DependencyProperty.Register("RightPaneContent", typeof(object), typeof(ApplicationMenu), new UIPropertyMetadata(null));

        /// <summary>
        /// Gets or sets application menu bottom pane content
        /// </summary>
        public object FooterPaneContent
        {
            get { return (object)GetValue(FooterPaneContentProperty); }
            set { SetValue(FooterPaneContentProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for BottomContent.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty FooterPaneContentProperty =
            DependencyProperty.Register("FooterPaneContent", typeof(object), typeof(ApplicationMenu), new UIPropertyMetadata(null));

        #endregion

        #region Initialization

        /// <summary>
        /// Static constructor
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static ApplicationMenu()
        {
            Type type = typeof(ApplicationMenu);

            // Override style metadata
            DefaultStyleKeyProperty.OverrideMetadata(type, new FrameworkPropertyMetadata(type));
            // Disable QAT for this control
            CanAddToQuickAccessToolBarProperty.OverrideMetadata(type, new FrameworkPropertyMetadata(false));
            // Make default KeyTip
            KeyTip.KeysProperty.AddOwner(type, new FrameworkPropertyMetadata(null, null, CoerceKeyTipKeys));
            StyleProperty.OverrideMetadata(typeof(ApplicationMenu), new FrameworkPropertyMetadata(null, new CoerceValueCallback(OnCoerceStyle)));
        }

        // Coerce object style
        static object OnCoerceStyle(DependencyObject d, object basevalue)
        {
            if (basevalue == null)
            {
                basevalue = (d as FrameworkElement).TryFindResource(typeof(ApplicationMenu));
            }

            return basevalue;
        }

        static object CoerceKeyTipKeys(DependencyObject d, object basevalue)
        {
            return basevalue ?? Ribbon.Localization.BackstageButtonKeyTip;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ApplicationMenu()
        {
            CoerceValue(KeyTip.KeysProperty);
        }

        void OnPopupOpened(object sender, EventArgs e)
        {
            Mouse.Capture(this, CaptureMode.SubTree);
        }

        #endregion

        #region Methods


        #endregion

        #region Overrides
        /*/// <summary>
        /// Invoked when an unhandled System.Windows.UIElement.PreviewMouseLeftButtonDown routed event 
        /// reaches an element in its route that is derived from this class. Implement this method to add 
        /// class handling for this event.
        /// </summary>
        /// <param name="e">The System.Windows.Input.MouseButtonEventArgs that contains the event data. 
        /// The event data reports that the left mouse button was pressed.</param>
        protected override void OnPreviewMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            Border buttonBorder = GetTemplateChild("PART_ButtonBorder") as Border;
            if (buttonBorder.IsMouseOver && IsDropDownOpen) IsDropDownOpen = false;
            else base.OnPreviewMouseLeftButtonDown(e);
        }
        */
        #endregion

        #region Quick Access Toolbar

        /// <summary>
        /// Gets control which represents shortcut item.
        /// This item MUST be syncronized with the original 
        /// and send command to original one control.
        /// </summary>
        /// <returns>Control which represents shortcut item</returns>
        public override FrameworkElement CreateQuickAccessItem()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
