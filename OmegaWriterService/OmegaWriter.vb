
Imports System.Configuration
Imports log4net.Repository.Hierarchy

Namespace YPWater.DataGather
    Public Class OmegaWriterService
        Inherits ServiceProcess.ServiceBase
        Private Shared ReadOnly Logger As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

#Region " �����������ɵĴ��� "

        Public Sub New()
            MyBase.New()

            ' �õ�������������������ġ�
            InitializeComponent()

            ' �� InitializeComponent() ����֮������κγ�ʼ��

        End Sub

        'UserService ��д dispose ����������б�
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        ' ���̵�����ڵ�
        <MTAThread()> _
        Shared Sub Main()
            Dim servicesToRun() As ServiceProcess.ServiceBase

            ' ��ͬһ�����п������в�ֹһ�� NT ������Ҫ��
            ' ��һ��������ӵ��˽��̣������������
            ' ������һ������������磬
            '
            '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
            '
            servicesToRun = New ServiceProcess.ServiceBase() {New OmegaWriterService()}

            ServiceProcess.ServiceBase.Run(servicesToRun)
        End Sub

        '���������������
        Private components As System.ComponentModel.IContainer

        'ע�⣺���¹��������������������
        ' ����ʹ�����������޸Ĵ˹��̡�
        ' ��Ҫʹ�ô���༭���޸�����
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            '
            'OmegaService
            '
            Me.CanShutdown = True
            Me.ServiceName = "OmegaGatherer"

        End Sub

#End Region

        Private _oWriter As IOmegaWriter


        Protected Overrides Sub OnStart(ByVal args() As String)
            Logger.Debug("Service OnStart")
            StartWriter()
        End Sub

        Protected Overrides Sub OnStop()
            _oWriter = Nothing
        End Sub

        Private Sub StartWriter()
            Logger.Debug("StartWriter")
            Try
                _oWriter = New IOmegaWriter()
                'aRegKey = Registry.LocalMachine.OpenSubKey("Software\YPWater.COM\DataGather.1\Writer")

                'oWriter.ConnString = aRegKey.GetValue("ConnString", "data source=SC_DB01;initial catalog=GATHER;integrated security=SSPI;packet size=4096")

                'oWriter.WorkPath = aRegKey.GetValue("WorkPath", "D:\Datas")
                'oWriter.TimerInterval = aRegKey.GetValue("TimerInterval", 1000)
                'oWriter.WriterInterval = aRegKey.GetValue("WriterInterval", 30)
                'aRegKey.Close()

                _oWriter.ConnString = ConfigurationManager.AppSettings("ConnString")
                _oWriter.WorkPath = ConfigurationManager.AppSettings("WorkPath")
                _oWriter.TimerInterval = CType(ConfigurationManager.AppSettings("TimerInterval"), Int16)
                _oWriter.WriterInterval = CType(ConfigurationManager.AppSettings("WriterInterval"), Int16)
                Logger.Debug("start OPC Connect")
                _oWriter.ConnectOPC()
                Logger.Debug("End OPC Connect")
                Logger.Debug("start load tags")
                _oWriter.LoadTags()
                Logger.Debug("end load tags")
                Logger.Debug("writer start")
                _oWriter.Start()
                Logger.Debug("end writer start")
            Catch ex As Exception
                Logger.Error(ex.Message, ex)
                EventLog.WriteEntry("Prepare Writer Failed: " & ex.Message, Diagnostics.EventLogEntryType.Error)
            Finally
                'aRegKey.Close()
            End Try
        End Sub

    End Class
End Namespace