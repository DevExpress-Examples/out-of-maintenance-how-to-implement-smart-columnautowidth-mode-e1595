# How to implement Smart ColumnAutoWidth mode


<p>The XtraGrid provides two built-in column resizing modes: manual and automatic. You can choose one using the GridView.OptionsView.ColumnAutoWidth property. However, in Auto mode the horizontal scrollbar is never enabled. This is a problem if columns are reduced to their minimum width and still don't fit into the view's client area. Also, a column width can be changed only relative to other columns, while manual mode lacks the useful stretching functionality when the control itself is resized.</p>
<p>This example demonstrates how to implement functionality similar to the one provided by ColumnAutoWidth mode and solve its drawbacks in user code.</p>

<br/>


