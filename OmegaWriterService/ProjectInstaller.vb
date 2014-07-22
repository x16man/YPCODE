Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)> Public Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

#Region " 组件设计器生成的代码 "

    Public Sub New()
        MyBase.New()

        '该调用是组件设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化

    End Sub

    'Installer 重写 dispose 以清理组件列表。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    '组件设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意：以下过程是组件设计器所必需的
    '可以使用组件设计器来修改此过程。
    '不要使用代码编辑器来修改它。
    Friend WithEvents OmegaProcessInstaller As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents OmegaInstaller As System.ServiceProcess.ServiceInstaller
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OmegaProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.OmegaInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'OmegaProcessInstaller
        '
        Me.OmegaProcessInstaller.Password = Nothing
        Me.OmegaProcessInstaller.Username = Nothing
        '
        'OmegaInstaller
        '
        Me.OmegaInstaller.Description = "针对第三方KEPWare OPC的数据采集服务。"
        Me.OmegaInstaller.DisplayName = "KEPWare OPC Gather"
        Me.OmegaInstaller.ServiceName = "KEPWare Gather"
        Me.OmegaInstaller.ServicesDependedOn = New String() {"MSMQ"}
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.OmegaProcessInstaller, Me.OmegaInstaller})

    End Sub

#End Region

End Class
