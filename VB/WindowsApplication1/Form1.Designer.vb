Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication1
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.defaultToolTipController1 = New DevExpress.Utils.DefaultToolTipController(Me.components)
			Me.customControl1 = New WindowsApplication1.CustomControl()
			Me.SuspendLayout()
			' 
			' customControl1
			' 
			Me.defaultToolTipController1.SetAllowHtmlText(Me.customControl1, DevExpress.Utils.DefaultBoolean.Default)
			Me.customControl1.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(0))))), (CInt(Fix((CByte(0))))), (CInt(Fix((CByte(192))))))
			Me.customControl1.ForeColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(255))))), (CInt(Fix((CByte(128))))), (CInt(Fix((CByte(0))))))
			Me.customControl1.Location = New System.Drawing.Point(37, 12)
			Me.customControl1.Name = "customControl1"
			Me.customControl1.Size = New System.Drawing.Size(398, 41)
			Me.customControl1.TabIndex = 0
			Me.customControl1.Text = "customControl1"
			' 
			' Form1
			' 
			Me.defaultToolTipController1.SetAllowHtmlText(Me, DevExpress.Utils.DefaultBoolean.Default)
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(554, 417)
			Me.Controls.Add(Me.customControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private defaultToolTipController1 As DevExpress.Utils.DefaultToolTipController
		Private customControl1 As CustomControl
	End Class
End Namespace

