Module ModGeneral
    Public dsRDC As New DataSet
    Public dtRDP As New DataTable

    Private m_bWithDrives As Boolean = False

    Public Property WithDrive() As Boolean
        Get
            Return m_bWithDrives
        End Get
        Set(ByVal value As Boolean)
            m_bWithDrives = value
        End Set
    End Property
End Module
