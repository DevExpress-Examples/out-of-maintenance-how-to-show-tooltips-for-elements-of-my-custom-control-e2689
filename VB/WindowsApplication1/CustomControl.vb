Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Utils

Namespace WindowsApplication1
	Public Class CustomControl
		Inherits Control
		Implements IToolTipControlClient

		Public Sub New()

		End Sub

		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			MyBase.OnPaint(e)
			MyDrawControl(e)
		End Sub
		Private Sub MyDrawControl(ByVal e As PaintEventArgs)
			DrawBackGround(e)
			DrawLine(e)
			DrawStart(e)
			DrawFinish(e)
		End Sub

		Private Sub DrawBackGround(ByVal e As PaintEventArgs)
			e.Graphics.FillRectangle(New SolidBrush(BackColor), ClientRectangle)
		End Sub
		Private Sub DrawLine(ByVal e As PaintEventArgs)
			e.Graphics.FillRectangle(New SolidBrush(ForeColor), GetLineBounds(e.Graphics))
		End Sub

		Private Sub DrawStart(ByVal e As PaintEventArgs)
			Dim rect As Rectangle = GetStartBounds(e.Graphics)
			e.Graphics.DrawString("Start", Font, New SolidBrush(ForeColor), rect)
		End Sub

		Private Sub DrawFinish(ByVal e As PaintEventArgs)
			Dim rect As Rectangle = GetFinishBounds(e.Graphics)
			e.Graphics.DrawString("Finish", Font, New SolidBrush(ForeColor), rect)
		End Sub

		Private Function GetLineBounds(ByVal e As Graphics) As RectangleF
			Dim rect1 As Rectangle = GetStartBounds(e)
			Dim rect2 As Rectangle = GetFinishBounds(e)
			Dim lineWidth As Integer = Width - rect1.Width - rect2.Width
			Dim rect As New Rectangle(rect1.Right, 0, lineWidth, Height)
			Return rect
		End Function


		Private Function GetStartBounds(ByVal g As Graphics) As Rectangle
			Dim size As Size = g.MeasureString("Start", Font).ToSize()
			Return New Rectangle(0, 0, size.Width + 5, Height)
		End Function

		Private Function GetFinishBounds(ByVal g As Graphics) As Rectangle
			Dim size As Size = g.MeasureString("Finish", Font).ToSize()
			Return New Rectangle(Width - size.Width, 0, size.Width + 5, Height)
		End Function

		Public Function GetHintText(ByVal p As Point) As String
			Dim graphics As Graphics = CreateGraphics()
			If GetStartBounds(graphics).Contains(p) Then
				Return "Start"
			End If
			If GetFinishBounds(graphics).Contains(p) Then
				Return "Finish"
			End If
			If GetLineBounds(graphics).Contains(p) Then
				Return "Line"
			End If
			Return "Custom control"
		End Function

		#Region "IToolTipControlClient Members"

		Private Function GetObjectInfo(ByVal point As Point) As ToolTipControlInfo Implements IToolTipControlClient.GetObjectInfo
			Dim hintText As String = GetHintText(point)
			Dim info As New ToolTipControlInfo()
			info.Object = hintText
			info.Text = hintText
			info.ToolTipPosition = Control.MousePosition
			info.Interval = 100
			info.Title = "Custom title"
			info.ToolTipType = ToolTipType.SuperTip
			Return info
		End Function



		Private ReadOnly Property ShowToolTips() As Boolean Implements IToolTipControlClient.ShowToolTips
			Get
				Return True
			End Get
		End Property

		#End Region
	End Class
End Namespace
