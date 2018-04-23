Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections

Namespace WindowsApplication8
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private columnWidths() As Integer 'keep user-defined column widths

		Private Sub gridControl1_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gridControl1.SizeChanged
			RecalcWidths(gridView1, columnWidths)
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			gridControl1.ForceInitialize()
			gridView1.OptionsView.ColumnAutoWidth = False
			columnWidths = New Integer(gridView1.Columns.Count - 1){}
			ResetWidths(gridView1, columnWidths)
			AddHandler gridView1.ColumnWidthChanged, AddressOf gridView1_ColumnWidthChanged
		End Sub

		Private Sub gridView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs)
			ResetWidths(TryCast(sender, GridView), columnWidths)
		End Sub

		Private Sub ResetWidths(ByVal view As GridView, ByVal widths() As Integer)
			For Each col As GridColumn In view.Columns
				widths(col.AbsoluteIndex) = col.Width
			Next col
			RecalcWidths(view, widths)
		End Sub

		Private Sub RecalcWidths(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal widths() As Integer)
			Dim info As GridViewInfo = TryCast(view.GetViewInfo(), GridViewInfo)

			Dim room As Integer = info.ViewRects.ColumnPanelWidth
			Dim sumWidth As Integer = 0
			Dim cols As New ArrayList()
			For Each col As GridColumn In view.VisibleColumns
				sumWidth += widths(col.AbsoluteIndex)
				cols.Add(col)
			Next col
			If sumWidth = 0 Then
				Return
			End If
			If sumWidth > room Then 'prevent extreme column squeezing
				Return
			End If
			Dim remains As Integer = room
			For Each col As GridColumn In cols
				col.Width = room * widths(col.AbsoluteIndex) / sumWidth
				remains -= col.Width
			Next col
			view.VisibleColumns(view.VisibleColumns.Count - 1).Width += remains
		End Sub
	End Class
End Namespace