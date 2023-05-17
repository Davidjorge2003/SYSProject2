package crc645cabfd7ad23a4b34;


public class NativeCustomScrollView
	extends crc6452ffdc5b34af3a0f.MauiScrollView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_computeScroll:()V:GetComputeScrollHandler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.Maui.DataGrid.Handler.NativeCustomScrollView, Syncfusion.Maui.DataGrid", NativeCustomScrollView.class, __md_methods);
	}


	public NativeCustomScrollView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == NativeCustomScrollView.class)
			mono.android.TypeManager.Activate ("Syncfusion.Maui.DataGrid.Handler.NativeCustomScrollView, Syncfusion.Maui.DataGrid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public NativeCustomScrollView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == NativeCustomScrollView.class)
			mono.android.TypeManager.Activate ("Syncfusion.Maui.DataGrid.Handler.NativeCustomScrollView, Syncfusion.Maui.DataGrid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public NativeCustomScrollView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == NativeCustomScrollView.class)
			mono.android.TypeManager.Activate ("Syncfusion.Maui.DataGrid.Handler.NativeCustomScrollView, Syncfusion.Maui.DataGrid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void computeScroll ()
	{
		n_computeScroll ();
	}

	private native void n_computeScroll ();


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
