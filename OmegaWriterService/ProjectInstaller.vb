Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)> Public Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

#Region " �����������ɵĴ��� "

    Public Sub New()
        MyBase.New()

        '�õ�������������������ġ�
        InitializeComponent()

        '�� InitializeComponent() ����֮������κγ�ʼ��

    End Sub

    'Installer ��д dispose ����������б�
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    '���������������
    Private components As System.ComponentModel.IContainer

    'ע�⣺���¹��������������������
    '����ʹ�������������޸Ĵ˹��̡�
    '��Ҫʹ�ô���༭�����޸�����
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
        Me.OmegaInstaller.Description = "��Ե�����KEPWare OPC�����ݲɼ�����"
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
