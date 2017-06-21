
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Данные сотрудника режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editiu_u_def
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IRowEditor

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    private mOnInit as boolean = false
    private mChanged as boolean = false
    public event Changed() Implements LATIR2GUIManager.IRowEditor.Changed 
    Public Event Saved() Implements LATIR2GUIManager.IRowEditor.Saved
    Public Event Refreshed() Implements LATIR2GUIManager.IRowEditor.Refreshed
    Public Sub Changing()
      if not mOnInit then
        mChanged = true
        raiseevent Changed()
      end if
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

 Dim iii As Integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lbltheClient  as  System.Windows.Forms.Label
Friend WithEvents txttheClient As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdtheClient As System.Windows.Forms.Button
Friend WithEvents lbllastname  as  System.Windows.Forms.Label
Friend WithEvents txtlastname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblsurname  as  System.Windows.Forms.Label
Friend WithEvents txtsurname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblcurRole  as  System.Windows.Forms.Label
Friend WithEvents txtcurRole As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdcurRole As System.Windows.Forms.Button
Friend WithEvents lblsendtomail  as  System.Windows.Forms.Label
Friend WithEvents cmbsendtomail As System.Windows.Forms.ComboBox
Friend cmbsendtomailDATA As DataTable
Friend cmbsendtomailDATAROW As DataRow
Friend WithEvents lblfreelancer  as  System.Windows.Forms.Label
Friend WithEvents cmbfreelancer As System.Windows.Forms.ComboBox
Friend cmbfreelancerDATA As DataTable
Friend cmbfreelancerDATAROW As DataRow
Friend WithEvents lblemail  as  System.Windows.Forms.Label
Friend WithEvents txtemail As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthephone  as  System.Windows.Forms.Label
Friend WithEvents txtthephone As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbllogin  as  System.Windows.Forms.Label
Friend WithEvents txtlogin As LATIR2GuiManager.TouchTextBox

<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

 Me.HolderPanel = New LATIR2GUIControls.AutoPanel
 Me.HolderPanel.SuspendLayout()
Me.SuspendLayout()
 '
'HolderPanel
'
Me.HolderPanel.AllowDrop = True
Me.HolderPanel.BackColor = System.Drawing.SystemColors.Control
Me.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.HolderPanel.Location = New System.Drawing.Point(0, 0)
Me.HolderPanel.Name = "HolderPanel"
Me.HolderPanel.Size = New System.Drawing.Size(232, 120)
Me.HolderPanel.TabIndex = 0
Me.lbltheClient = New System.Windows.Forms.Label
Me.txttheClient = New LATIR2GuiManager.TouchTextBox
Me.cmdtheClient = New System.Windows.Forms.Button
Me.lbllastname = New System.Windows.Forms.Label
Me.txtlastname = New LATIR2GuiManager.TouchTextBox
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblsurname = New System.Windows.Forms.Label
Me.txtsurname = New LATIR2GuiManager.TouchTextBox
Me.lblcurRole = New System.Windows.Forms.Label
Me.txtcurRole = New LATIR2GuiManager.TouchTextBox
Me.cmdcurRole = New System.Windows.Forms.Button
Me.lblsendtomail = New System.Windows.Forms.Label
Me.cmbsendtomail = New System.Windows.Forms.ComboBox
Me.lblfreelancer = New System.Windows.Forms.Label
Me.cmbfreelancer = New System.Windows.Forms.ComboBox
Me.lblemail = New System.Windows.Forms.Label
Me.txtemail = New LATIR2GuiManager.TouchTextBox
Me.lblthephone = New System.Windows.Forms.Label
Me.txtthephone = New LATIR2GuiManager.TouchTextBox
Me.lbllogin = New System.Windows.Forms.Label
Me.txtlogin = New LATIR2GuiManager.TouchTextBox

Me.lbltheClient.Location = New System.Drawing.Point(20,5)
Me.lbltheClient.name = "lbltheClient"
Me.lbltheClient.Size = New System.Drawing.Size(200, 20)
Me.lbltheClient.TabIndex = 1
Me.lbltheClient.Text = "Клиент"
Me.lbltheClient.ForeColor = System.Drawing.Color.Black
Me.txttheClient.Location = New System.Drawing.Point(20,27)
Me.txttheClient.name = "txttheClient"
Me.txttheClient.ReadOnly = True
Me.txttheClient.Size = New System.Drawing.Size(176, 20)
Me.txttheClient.TabIndex = 2
Me.txttheClient.Text = "" 
Me.cmdtheClient.Location = New System.Drawing.Point(198,27)
Me.cmdtheClient.name = "cmdtheClient"
Me.cmdtheClient.Size = New System.Drawing.Size(22, 20)
Me.cmdtheClient.TabIndex = 3
Me.cmdtheClient.Text = "..." 
Me.lbllastname.Location = New System.Drawing.Point(20,52)
Me.lbllastname.name = "lbllastname"
Me.lbllastname.Size = New System.Drawing.Size(200, 20)
Me.lbllastname.TabIndex = 4
Me.lbllastname.Text = "Фамилия"
Me.lbllastname.ForeColor = System.Drawing.Color.Black
Me.txtlastname.Location = New System.Drawing.Point(20,74)
Me.txtlastname.name = "txtlastname"
Me.txtlastname.Size = New System.Drawing.Size(200, 20)
Me.txtlastname.TabIndex = 5
Me.txtlastname.Text = "" 
Me.lblname.Location = New System.Drawing.Point(20,99)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 6
Me.lblname.Text = "Имя"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,121)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 7
Me.txtname.Text = "" 
Me.lblsurname.Location = New System.Drawing.Point(20,146)
Me.lblsurname.name = "lblsurname"
Me.lblsurname.Size = New System.Drawing.Size(200, 20)
Me.lblsurname.TabIndex = 8
Me.lblsurname.Text = "Отчество"
Me.lblsurname.ForeColor = System.Drawing.Color.Blue
Me.txtsurname.Location = New System.Drawing.Point(20,168)
Me.txtsurname.name = "txtsurname"
Me.txtsurname.Size = New System.Drawing.Size(200, 20)
Me.txtsurname.TabIndex = 9
Me.txtsurname.Text = "" 
Me.lblcurRole.Location = New System.Drawing.Point(20,193)
Me.lblcurRole.name = "lblcurRole"
Me.lblcurRole.Size = New System.Drawing.Size(200, 20)
Me.lblcurRole.TabIndex = 10
Me.lblcurRole.Text = "Роль в производстве"
Me.lblcurRole.ForeColor = System.Drawing.Color.Black
Me.txtcurRole.Location = New System.Drawing.Point(20,215)
Me.txtcurRole.name = "txtcurRole"
Me.txtcurRole.ReadOnly = True
Me.txtcurRole.Size = New System.Drawing.Size(176, 20)
Me.txtcurRole.TabIndex = 11
Me.txtcurRole.Text = "" 
Me.cmdcurRole.Location = New System.Drawing.Point(198,215)
Me.cmdcurRole.name = "cmdcurRole"
Me.cmdcurRole.Size = New System.Drawing.Size(22, 20)
Me.cmdcurRole.TabIndex = 12
Me.cmdcurRole.Text = "..." 
Me.lblsendtomail.Location = New System.Drawing.Point(20,240)
Me.lblsendtomail.name = "lblsendtomail"
Me.lblsendtomail.Size = New System.Drawing.Size(200, 20)
Me.lblsendtomail.TabIndex = 13
Me.lblsendtomail.Text = "Оповещать по почте"
Me.lblsendtomail.ForeColor = System.Drawing.Color.Black
Me.cmbsendtomail.Location = New System.Drawing.Point(20,262)
Me.cmbsendtomail.name = "cmbsendtomail"
Me.cmbsendtomail.Size = New System.Drawing.Size(200,  20)
Me.cmbsendtomail.TabIndex = 14
Me.lblfreelancer.Location = New System.Drawing.Point(20,287)
Me.lblfreelancer.name = "lblfreelancer"
Me.lblfreelancer.Size = New System.Drawing.Size(200, 20)
Me.lblfreelancer.TabIndex = 15
Me.lblfreelancer.Text = "Удаленная работа"
Me.lblfreelancer.ForeColor = System.Drawing.Color.Black
Me.cmbfreelancer.Location = New System.Drawing.Point(20,309)
Me.cmbfreelancer.name = "cmbfreelancer"
Me.cmbfreelancer.Size = New System.Drawing.Size(200,  20)
Me.cmbfreelancer.TabIndex = 16
Me.lblemail.Location = New System.Drawing.Point(20,334)
Me.lblemail.name = "lblemail"
Me.lblemail.Size = New System.Drawing.Size(200, 20)
Me.lblemail.TabIndex = 17
Me.lblemail.Text = "e-mail"
Me.lblemail.ForeColor = System.Drawing.Color.Blue
Me.txtemail.Location = New System.Drawing.Point(20,356)
Me.txtemail.name = "txtemail"
Me.txtemail.Size = New System.Drawing.Size(200, 20)
Me.txtemail.TabIndex = 18
Me.txtemail.Text = "" 
Me.lblthephone.Location = New System.Drawing.Point(20,381)
Me.lblthephone.name = "lblthephone"
Me.lblthephone.Size = New System.Drawing.Size(200, 20)
Me.lblthephone.TabIndex = 19
Me.lblthephone.Text = "Телефон"
Me.lblthephone.ForeColor = System.Drawing.Color.Blue
Me.txtthephone.Location = New System.Drawing.Point(20,403)
Me.txtthephone.name = "txtthephone"
Me.txtthephone.Size = New System.Drawing.Size(200, 20)
Me.txtthephone.TabIndex = 20
Me.txtthephone.Text = "" 
Me.lbllogin.Location = New System.Drawing.Point(230,5)
Me.lbllogin.name = "lbllogin"
Me.lbllogin.Size = New System.Drawing.Size(200, 20)
Me.lbllogin.TabIndex = 21
Me.lbllogin.Text = "Имя для входа"
Me.lbllogin.ForeColor = System.Drawing.Color.Black
Me.txtlogin.Location = New System.Drawing.Point(230,27)
Me.txtlogin.name = "txtlogin"
Me.txtlogin.Size = New System.Drawing.Size(200, 20)
Me.txtlogin.TabIndex = 22
Me.txtlogin.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheClient)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheClient)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtheClient)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllastname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlastname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsurname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsurname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcurRole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtcurRole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdcurRole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsendtomail)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbsendtomail)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfreelancer)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbfreelancer)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblemail)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtemail)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthephone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthephone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllogin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlogin)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editiu_u_def"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txttheClient_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheClient.TextChanged
  Changing

end sub
private sub cmdtheClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtheClient.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("bpc_info","",System.guid.Empty, id, brief) Then
          txttheClient.Tag = id
          txttheClient.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtlastname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlastname.TextChanged
  Changing

end sub
private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub txtsurname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsurname.TextChanged
  Changing

end sub
private sub txtcurRole_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcurRole.TextChanged
  Changing

end sub
private sub cmdcurRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcurRole.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("iu_crole","",System.guid.Empty, id, brief) Then
          txtcurRole.Tag = id
          txtcurRole.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbsendtomail_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsendtomail.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbfreelancer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbfreelancer.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtemail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtemail.TextChanged
  Changing

end sub
private sub txtthephone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthephone.TextChanged
  Changing

end sub
private sub txtlogin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlogin.TextChanged
  Changing

end sub

Public Item As bpu.bpu.iu_u_def
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,bpu.bpu.iu_u_def)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.theClient Is Nothing Then
  txttheClient.Tag = item.theClient.id
  txttheClient.text = item.theClient.brief
else
  txttheClient.Tag = System.Guid.Empty 
  txttheClient.text = "" 
End If
txtlastname.text = item.lastname
txtname.text = item.name
txtsurname.text = item.surname
If Not item.curRole Is Nothing Then
  txtcurRole.Tag = item.curRole.id
  txtcurRole.text = item.curRole.brief
else
  txtcurRole.Tag = System.Guid.Empty 
  txtcurRole.text = "" 
End If
cmbsendtomailData = New DataTable
cmbsendtomailData.Columns.Add("name", GetType(System.String))
cmbsendtomailData.Columns.Add("Value", GetType(System.Int32))
try
cmbsendtomailDataRow = cmbsendtomailData.NewRow
cmbsendtomailDataRow("name") = "Да"
cmbsendtomailDataRow("Value") = -1
cmbsendtomailData.Rows.Add (cmbsendtomailDataRow)
cmbsendtomailDataRow = cmbsendtomailData.NewRow
cmbsendtomailDataRow("name") = "Нет"
cmbsendtomailDataRow("Value") = 0
cmbsendtomailData.Rows.Add (cmbsendtomailDataRow)
cmbsendtomail.DisplayMember = "name"
cmbsendtomail.ValueMember = "Value"
cmbsendtomail.DataSource = cmbsendtomailData
 cmbsendtomail.SelectedValue=CInt(Item.sendtomail)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbfreelancerData = New DataTable
cmbfreelancerData.Columns.Add("name", GetType(System.String))
cmbfreelancerData.Columns.Add("Value", GetType(System.Int32))
try
cmbfreelancerDataRow = cmbfreelancerData.NewRow
cmbfreelancerDataRow("name") = "Да"
cmbfreelancerDataRow("Value") = -1
cmbfreelancerData.Rows.Add (cmbfreelancerDataRow)
cmbfreelancerDataRow = cmbfreelancerData.NewRow
cmbfreelancerDataRow("name") = "Нет"
cmbfreelancerDataRow("Value") = 0
cmbfreelancerData.Rows.Add (cmbfreelancerDataRow)
cmbfreelancer.DisplayMember = "name"
cmbfreelancer.ValueMember = "Value"
cmbfreelancer.DataSource = cmbfreelancerData
 cmbfreelancer.SelectedValue=CInt(Item.freelancer)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtemail.text = item.email
txtthephone.text = item.thephone
txtlogin.text = item.login
        mOnInit = false
  raiseevent Refreshed()
end sub


''' <summary>
'''Сохранения данных в полях объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Save() Implements LATIR2GUIManager.IRowEditor.Save
  if mRowReadOnly =false then

If not txttheClient.Tag.Equals(System.Guid.Empty) Then
  item.theClient = Item.Application.FindRowObject("bpc_info",txttheClient.Tag)
Else
   item.theClient = Nothing
End If
item.lastname = txtlastname.text
item.name = txtname.text
item.surname = txtsurname.text
If not txtcurRole.Tag.Equals(System.Guid.Empty) Then
  item.curRole = Item.Application.FindRowObject("iu_crole",txtcurRole.Tag)
Else
   item.curRole = Nothing
End If
   item.sendtomail = cmbsendtomail.SelectedValue
   item.freelancer = cmbfreelancer.SelectedValue
item.email = txtemail.text
item.thephone = txtthephone.text
item.login = txtlogin.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txttheClient.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtlastname.text <> "" ) 
if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK = not txtcurRole.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbsendtomail.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbfreelancer.SelectedIndex >=0)
if mIsOK then mIsOK =( txtlogin.text <> "" ) 
 return mIsOK
end function
Public function IsChanged() as boolean Implements LATIR2GUIManager.IRowEditor.IsChanged
 return mChanged
end function
Public Sub SetupPanel()
    HolderPanel.SetupPanel()
End Sub
Public Overridable Function GetMaxX() As Double
    Return HolderPanel.GetMaxX()
End Function
Public Overridable Function GetMaxY() As Double
    Return HolderPanel.GetMaxY()
End Function
end class
