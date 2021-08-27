<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1595)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication8/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication8/Form1.vb))
<!-- default file list end -->
# How to implement Smart ColumnAutoWidth mode


<p>The XtraGrid provides two built-in column resizing modes: manual and automatic. You can choose one using the GridView.OptionsView.ColumnAutoWidth property. However, in Auto mode the horizontal scrollbar is never enabled. This is a problem if columns are reduced to their minimum width and still don't fit into the view's client area. Also, a column width can be changed only relative to other columns, while manual mode lacks the useful stretching functionality when the control itself is resized.</p>
<p>This example demonstrates how to implement functionality similar to the one provided by ColumnAutoWidth mode and solve its drawbacks in user code.</p>

<br/>


