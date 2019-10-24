using System;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public enum FcObjectId {

        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("family")]
        FC_FAMILY,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("style")]
        FC_STYLE,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("slant")]
        FC_SLANT,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("weight")]
        FC_WEIGHT,


        ///<summary>
        /// Range
        ///</summary>
        [ToolkitOption("size")]
        FC_SIZE,


        ///<summary>
        /// Double
        ///</summary>
        [ToolkitOption("aspect")]
        FC_ASPECT,


        ///<summary>
        /// Double
        ///</summary>
        [ToolkitOption("pixelsize")]
        FC_PIXEL_SIZE,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("spacing")]
        FC_SPACING,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("foundry")]
        FC_FOUNDRY,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("antialias")]
        FC_ANTIALIAS,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("hinting")]
        FC_HINTING,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("hintstyle")]
        FC_HINT_STYLE,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("verticallayout")]
        FC_VERTICAL_LAYOUT,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("autohint")]
        FC_AUTOHINT,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("width")]
        FC_WIDTH,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("file")]
        FC_FILE,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("index")]
        FC_INDEX,


        ///<summary>
        /// FT_Face
        ///</summary>
        [ToolkitOption("ftface")]
        FC_FT_FACE,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("outline")]
        FC_OUTLINE,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("scalable")]
        FC_SCALABLE,


        ///<summary>
        /// double
        ///</summary>
        [ToolkitOption("dpi")]
        FC_DPI,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("rgba")]
        FC_RGBA,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("minspace")]
        FC_MINSPACE,


        ///<summary>
        /// CharSet
        ///</summary>
        [ToolkitOption("charset")]
        FC_CHARSET,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("lang")]
        FC_LANG,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("fontversion")]
        FC_FONTVERSION,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("fullname")]
        FC_FULLNAME,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("familylang")]
        FC_FAMILYLANG,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("stylelang")]
        FC_STYLELANG,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("fullnamelang")]
        FC_FULLNAMELANG,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("capability")]
        FC_CAPABILITY,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("fontformat")]
        FC_FONTFORMAT,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("embolden")]
        FC_EMBOLDEN,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("embeddedbitmap")]
        FC_EMBEDDED_BITMAP,


        ///<summary>
        /// Bool
        ///</summary>
        [ToolkitOption("decorative")]
        FC_DECORATIVE,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("lcdfilter")]
        FC_LCD_FILTER,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("fontfeatures")]
        FC_FONT_FEATURES,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("namelang")]
        FC_NAMELANG,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("prgname")]
        FC_PRGNAME,


        ///<summary>
        /// String
        ///</summary>
        [ToolkitOption("postscriptname")]
        FC_POSTSCRIPT_NAME,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("charwidth")]
        FC_CHAR_WIDTH,


        ///<summary>
        /// Int
        ///</summary>
        [ToolkitOption("charheight")]
        FC_CHAR_HEIGHT,


        ///<summary>
        /// FcMatrix
        ///</summary>
        [ToolkitOption("matrix")]
        FC_MATRIX,

    }
}
