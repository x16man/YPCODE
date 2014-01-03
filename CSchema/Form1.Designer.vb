<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.AxSpreadsheet1 = New AxOWC10.AxSpreadsheet
        CType(Me.AxSpreadsheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxSpreadsheet1
        '
        Me.AxSpreadsheet1.DataSource = Nothing
        Me.AxSpreadsheet1.Enabled = True
        Me.AxSpreadsheet1.Location = New System.Drawing.Point(47, 89)
        Me.AxSpreadsheet1.Name = "AxSpreadsheet1"
        Me.AxSpreadsheet1.OcxState = CType(resources.GetObject("AxSpreadsheet1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxSpreadsheet1.Size = New System.Drawing.Size(576, 288)
        Me.AxSpreadsheet1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.AxSpreadsheet1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.AxSpreadsheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxSpreadsheet1 As AxOWC10.AxSpreadsheet
End Class
