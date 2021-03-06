﻿//======================================================================
//
//        Copyright © 2017 NetInfo Technologies Ltd.
//        All rights reserved
//        guid1:                    a482a398-ac6d-4fbf-a4e9-0682db475e36
//        CLR Version:              4.0.30319.42000
//        Name:                     CellStyleViewModel
//        Computer:                 CHARLEY-PC
//        Organization:             NetInfo
//        Namespace:                ReportDesigner.Models
//        File Name:                CellStyleViewModel
//
//        Created by Charley at 2017/4/26 11:54:42
//        http://www.netinfo.com 
//
//======================================================================

using System.Windows;
using System.Windows.Media;
using NetInfo.EMP.Reports;


namespace ReportDesigner.Models
{
    public class CellStyleViewModel : ViewModel
    {
        private string mName;

        public string Name
        {
            get { return mName; }
            set { mName = value; OnPropertyChanged("Name"); }
        }

        private FontFamily mFontFamily;

        public FontFamily FontFamily
        {
            get { return mFontFamily; }
            set { mFontFamily = value; OnPropertyChanged("FontFamily"); }
        }

        private int mFontSize;

        public int FontSize
        {
            get { return mFontSize; }
            set { mFontSize = value; OnPropertyChanged("FontSize"); }
        }

        private FontWeight mFontWeight;

        public FontWeight FontWeight
        {
            get { return mFontWeight; }
            set { mFontWeight = value; OnPropertyChanged("FontWeight"); }
        }

        private System.Windows.FontStyle mFontStyle;

        public System.Windows.FontStyle FontStyle
        {
            get { return mFontStyle; }
            set { mFontStyle = value; OnPropertyChanged("FontStyle"); }
        }

        private Brush mForeground;

        public Brush Foreground
        {
            get { return mForeground; }
            set { mForeground = value; OnPropertyChanged("Foreground"); }
        }

        private Brush mBackground;

        public Brush Background
        {
            get { return mBackground; }
            set { mBackground = value; OnPropertyChanged("Background"); }
        }

        private HorizontalAlignment mHorizontalAlignment;

        public HorizontalAlignment HorizontalAlignment
        {
            get { return mHorizontalAlignment; }
            set { mHorizontalAlignment = value; OnPropertyChanged("HorizontalAlignment"); }
        }

        private VerticalAlignment mVerticalAlignment;

        public VerticalAlignment VerticalAlignment
        {
            get { return mVerticalAlignment; }
            set { mVerticalAlignment = value; OnPropertyChanged("VerticalAlignment"); }
        }

        public void SetStyle()
        {
            if (CellStyle == null) { return;}
            var style = CellStyle.Style;
            if (style == null) { return; }
            FontFamily = new FontFamily(style.FontFamily);
            FontSize = style.FontSize;
            FontWeight = (style.FontStyle & (int)NetInfo.EMP.Reports.FontStyle.Bold) > 0
                ? FontWeights.Bold
                : FontWeights.Normal;
            FontStyle = (style.FontStyle & (int)NetInfo.EMP.Reports.FontStyle.Italic) > 0
                ? FontStyles.Italic
                : FontStyles.Normal;
            if (!string.IsNullOrEmpty(style.ForeColor))
            {
                var color = ColorConverter.ConvertFromString(style.ForeColor);
                if (color != null)
                {
                    Foreground = new SolidColorBrush((Color)color);
                }
            }
            if (!string.IsNullOrEmpty(style.BackColor))
            {
                var color = ColorConverter.ConvertFromString(style.BackColor);
                if (color != null)
                {
                    Background = new SolidColorBrush((Color)color);
                }
            }
            HorizontalAlignment = (HorizontalAlignment)style.HAlign;
            VerticalAlignment = (VerticalAlignment)style.VAlign;
        }

        public CellStyleInfo CellStyle { get; set; }
    }
}
