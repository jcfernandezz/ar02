<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Leidos = New System.Windows.Forms.TextBox
        Me.Integrados = New System.Windows.Forms.TextBox
        Me.Rechazados = New System.Windows.Forms.TextBox
        Me.COMPLeidos = New System.Windows.Forms.TextBox
        Me.COMPIntegrados = New System.Windows.Forms.TextBox
        Me.COMPRechazados = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Leidos
        '
        Me.Leidos.Location = New System.Drawing.Point(185, 78)
        Me.Leidos.Name = "Leidos"
        Me.Leidos.Size = New System.Drawing.Size(100, 20)
        Me.Leidos.TabIndex = 0
        '
        'Integrados
        '
        Me.Integrados.Location = New System.Drawing.Point(185, 104)
        Me.Integrados.Name = "Integrados"
        Me.Integrados.Size = New System.Drawing.Size(100, 20)
        Me.Integrados.TabIndex = 1
        '
        'Rechazados
        '
        Me.Rechazados.Location = New System.Drawing.Point(185, 130)
        Me.Rechazados.Name = "Rechazados"
        Me.Rechazados.Size = New System.Drawing.Size(100, 20)
        Me.Rechazados.TabIndex = 2
        '
        'COMPLeidos
        '
        Me.COMPLeidos.Location = New System.Drawing.Point(185, 240)
        Me.COMPLeidos.Name = "COMPLeidos"
        Me.COMPLeidos.Size = New System.Drawing.Size(100, 20)
        Me.COMPLeidos.TabIndex = 3
        '
        'COMPIntegrados
        '
        Me.COMPIntegrados.Location = New System.Drawing.Point(185, 266)
        Me.COMPIntegrados.Name = "COMPIntegrados"
        Me.COMPIntegrados.Size = New System.Drawing.Size(100, 20)
        Me.COMPIntegrados.TabIndex = 4
        '
        'COMPRechazados
        '
        Me.COMPRechazados.Location = New System.Drawing.Point(185, 292)
        Me.COMPRechazados.Name = "COMPRechazados"
        Me.COMPRechazados.Size = New System.Drawing.Size(100, 20)
        Me.COMPRechazados.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(106, 345)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 13)
        Me.TextBox1.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(251, 384)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 488)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.COMPRechazados)
        Me.Controls.Add(Me.COMPIntegrados)
        Me.Controls.Add(Me.COMPLeidos)
        Me.Controls.Add(Me.Rechazados)
        Me.Controls.Add(Me.Integrados)
        Me.Controls.Add(Me.Leidos)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Leidos As System.Windows.Forms.TextBox
    Friend WithEvents Integrados As System.Windows.Forms.TextBox
    Friend WithEvents Rechazados As System.Windows.Forms.TextBox
    Friend WithEvents COMPLeidos As System.Windows.Forms.TextBox
    Friend WithEvents COMPIntegrados As System.Windows.Forms.TextBox
    Friend WithEvents COMPRechazados As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
