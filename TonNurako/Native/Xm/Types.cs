//
// ﾄﾝﾇﾗｺ
// 
// Motif
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Motif
{
    /// <summary>
	/// Motif用構造体
	/// </summary>
	internal class XmStruct
	{
		/// <summary>
		/// 汎用ｲﾍﾞﾝﾄ
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct XmAnyCallbackStruct
		{
			public int		reason;
			public IntPtr	xevent;
		}


		/// <summary>
		/// ToggleButtonに来る
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct XmToggleButtonCallbackStruct
		{
			public int		reason;
			public IntPtr	xevent;
			public int		set;
		}

		/// <summary>
		/// PushButtonに来る
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct XmPushButtonCallbackStruct
		{
			public int		reason;
			public IntPtr	xevent;
			public int		click_count;
		}

		/// <summary>
		/// ScrollBarに来る
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct XmScrollBarCallbackStruct
		{
			public int		reason;
			public IntPtr	xevent;
            public int value;
            public int pixel;
		}
		/// <summary>
		/// DrawingAreaに来る
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct XmDrawingAreaCallbackStruct
		{
			public int		reason;
			public IntPtr	xevent;
			public ulong	click_count;

		}

		/// <summary>
		/// TabStackに来る
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct XmTabStackCallbackStruct
		{
			public int		reason;
			public IntPtr	xevent;
			public IntPtr	selected_child;

		}

		/// <summary>
		/// DrawnButtonに来る
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
	   internal struct XmDrawnButtonCallbackStruct
		{
			public int		reason;
			public IntPtr	xevent;
			public IntPtr	window;
			public int		click_count;

		}

		/// <summary>
		/// Scaleに来る
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
		internal struct XmScaleCallbackStruct
		{
			public int		reason;
			public IntPtr	xevent;
			public int		val;
		};

		/// <summary>
		/// SpinBoxに来る
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct XmSpinBoxCallbackStruct
		{
			public int    reason;
			public IntPtr xevent;
			public IntPtr widget;
			[MarshalAs(UnmanagedType.U1)] public bool   doit;
			public int    position;
			public IntPtr val;
			[MarshalAs(UnmanagedType.U1)] public bool   crossed_boundary;
		}

		/// <summary>
		/// Managerに来る
		/// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct XmPopupHandlerCallbackStruct {
            public int reason; // int
            public IntPtr xevent; // XEvent*
            public IntPtr menuToPost; // Widget
            [MarshalAs(UnmanagedType.U1)] public bool postIt; // Boolean
            public IntPtr target; // Widget
        }

		/// <summary>
		/// SimpleSpinBoxに来る
		/// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct XmSimpleSpinBoxCallbackStruct {
            public int reason; // int
            public IntPtr xevent; // XEvent*
            public IntPtr widget; // Widget
            [MarshalAs(UnmanagedType.U1)] public bool doit; // Boolean
            public int position; // int
            public IntPtr value; // XmString
            [MarshalAs(UnmanagedType.U1)] public bool crossed_boundary; // Boolean
        }

		/// <summary>
		/// ComboBoxに来る
		/// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct XmComboBoxCallbackStruct {
            public int reason; // int
            public IntPtr xevent; // XEvent*
            public IntPtr item_or_text; // XmString
            public int item_position; // Widget

        }

		/// <summary>
		/// XmTextVerify (doitに注意)
		/// </summary>
       [StructLayout(LayoutKind.Sequential)]
        internal struct XmTextVerifyCallbackStruct
        {
            public int     reason;
            public IntPtr  xevent;
            [MarshalAs(UnmanagedType.U1)] public bool    doit;
            public long     currInsert;
            public long     newInsert;
            public long     startPos;
            public long     endPos;

            public IntPtr textBlock;
        }

        // XmTextVerifyの続き
        [StructLayout(LayoutKind.Sequential)]
        internal struct XmTextBlockRec {
           public IntPtr ptr;
           public int length;
           public long format;
       }


		/// <summary>
		/// Listに来る
		/// </summary>
       [StructLayout(LayoutKind.Sequential)]
        internal struct XmListCallbackStruct {
            public int reason; // int
            internal IntPtr xevent; // XEvent*
            internal IntPtr item; // XmString
            public int item_length; // int
            public int item_position; // int
            internal IntPtr selected_items; // XmString*
            public int selected_item_count; // int
            internal IntPtr selected_item_positions; // int*
            public char selection_type; // char
            public byte auto_selection_type; // unsigned char
        }


		/// <summary>
		/// Destination系
		/// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct XmDestinationCallbackStruct {
            public int reason; // int
            internal IntPtr xevent; // XEvent*
            public ulong selection; // Atom
            public byte operation; // XtEnum
            public int flags; // int
            internal IntPtr transfer_id; // XtPointer
            internal IntPtr destination_data; // XtPointer
            internal IntPtr location_data; // XtPointer
            public uint time; // Time
        }

		/// <summary>
		/// FileSelectionBoxに来る
		/// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XmFileSelectionBoxCallbackStruct {
            public int reason; // int
            internal IntPtr xevent; // XEvent*
            internal IntPtr xvalue; // XmString
            public int length; // int
            internal IntPtr mask; // XmString
            public int mask_length; // int
            internal IntPtr dir; // XmString
            public int dir_length; // int
            internal IntPtr pattern; // XmString
            public int pattern_length; // int
       }
	}
}
