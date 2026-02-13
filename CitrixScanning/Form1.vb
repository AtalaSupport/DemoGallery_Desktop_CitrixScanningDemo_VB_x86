Public Class Form1
    Private _acquisition As Acquisition
    Private _device As Device
    Private _deviceName As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Be sure to provide a parent to the Acquisition object.
        _acquisition = New Acquisition(Me)
        If _acquisition.SystemHasTwain = False OrElse _acquisition.Devices.Count = 0 Then
            MessageBox.Show("No compatible scanners were found on this system.", "No Scanners Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

        _deviceName = _acquisition.Devices.Default.Identity.ProductName

        AddHandler _acquisition.ImageAcquired, AddressOf _acquisition_ImageAcquired
        AddHandler _acquisition.AcquireFinished, AddressOf _acquisition_AcquireFinished
        AddHandler _acquisition.AcquireCanceled, AddressOf _acquisition_AcquireCanceled
        AddHandler _acquisition.AsynchronousException, AddressOf _acquisition_AsynchronousException
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        DisposeDevice()
        If Not _acquisition Is Nothing Then
            _acquisition.Dispose()
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim dev As Device = _acquisition.ShowSelectSource()
        If Not dev Is Nothing Then
            _deviceName = dev.Identity.ProductName
        End If
    End Sub

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        ' CreateDeviceSession returns a new temporary Device object to scan with.
        ' This device cannot be opened and closed more than once and you must 
        ' dispose the object when finished with the scan.
        _device = _acquisition.CreateDeviceSession(_deviceName)
        If _device Is Nothing Then
            MessageBox.Show("We were unable to create the device session for '" & _deviceName & "'.", "Create Device Session Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            _device.Open()
        Catch ex As Exception
            MessageBox.Show("We were unable to open the device." & Constants.vbCrLf & Constants.vbCrLf & ex.Message, "Open Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisposeDevice()
            Return
        End Try

        _device.ThreadingEnabled = True
        _device.TransferCount = 1
        _device.TransferMethod = TwainTransferMethod.TWSX_NATIVE
        _device.PixelType = ImagePixelType.BlackAndWhite
        _device.Resolution = New TwainResolution(300, 300)
        _device.Acquire()
    End Sub

    Private Sub _acquisition_AcquireFinished(ByVal sender As Object, ByVal e As EventArgs)
        DisposeDevice()
    End Sub

    Private Sub _acquisition_AcquireCanceled(ByVal sender As Object, ByVal e As EventArgs)
        DisposeDevice()
    End Sub

    Private Sub _acquisition_ImageAcquired(ByVal sender As Object, ByVal e As AcquireEventArgs)
        If Not e.Image Is Nothing Then
            MessageBox.Show("Image:  " & e.Image.PixelFormat.ToString() & " - " & e.Image.Width.ToString() & " x " & e.Image.Height.ToString(), "Image Acquired", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Image.Dispose()
        End If
    End Sub

    Private Sub _acquisition_AsynchronousException(ByVal sender As Object, ByVal e As AsynchronousExceptionEventArgs)
        DisposeDevice()
        MessageBox.Show("There was an error while scanning." & Constants.vbCrLf & Constants.vbCrLf & e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub DisposeDevice()
        If Not _device Is Nothing Then
            _device.Dispose()
            _device = Nothing
        End If
    End Sub
End Class