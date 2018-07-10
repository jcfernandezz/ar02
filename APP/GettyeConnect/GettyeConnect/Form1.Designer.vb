<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Leidos = New System.Windows.Forms.TextBox
        Me.Integrados = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Rechazados = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.COMPLeidos = New System.Windows.Forms.TextBox
        Me.COMPIntegrados = New System.Windows.Forms.TextBox
        Me.COMPRechazados = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Cerrar = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Ejecutar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INTEGRACIÓN CLIENTES ..."
        '
        'Leidos
        '
        Me.Leidos.Enabled = False
        Me.Leidos.Location = New System.Drawing.Point(191, 46)
        Me.Leidos.Name = "Leidos"
        Me.Leidos.Size = New System.Drawing.Size(100, 20)
        Me.Leidos.TabIndex = 1
        Me.Leidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Integrados
        '
        Me.Integrados.Enabled = False
        Me.Integrados.Location = New System.Drawing.Point(191, 72)
        Me.Integrados.Name = "Integrados"
        Me.Integrados.Size = New System.Drawing.Size(100, 20)
        Me.Integrados.TabIndex = 2
        Me.Integrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Registros leídos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Registros integrados"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Registros rechazados"
        '
        'Rechazados
        '
        Me.Rechazados.Enabled = False
        Me.Rechazados.Location = New System.Drawing.Point(191, 99)
        Me.Rechazados.Name = "Rechazados"
        Me.Rechazados.Size = New System.Drawing.Size(100, 20)
        Me.Rechazados.TabIndex = 6
        Me.Rechazados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(186, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "INTEGRACIÓN COMPROBANTES ..."
        '
        'COMPLeidos
        '
        Me.COMPLeidos.Enabled = False
        Me.COMPLeidos.Location = New System.Drawing.Point(191, 169)
        Me.COMPLeidos.Name = "COMPLeidos"
        Me.COMPLeidos.Size = New System.Drawing.Size(100, 20)
        Me.COMPLeidos.TabIndex = 8
        Me.COMPLeidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'COMPIntegrados
        '
        Me.COMPIntegrados.Enabled = False
        Me.COMPIntegrados.Location = New System.Drawing.Point(191, 196)
        Me.COMPIntegrados.Name = "COMPIntegrados"
        Me.COMPIntegrados.Size = New System.Drawing.Size(100, 20)
        Me.COMPIntegrados.TabIndex = 9
        Me.COMPIntegrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'COMPRechazados
        '
        Me.COMPRechazados.Enabled = False
        Me.COMPRechazados.Location = New System.Drawing.Point(191, 223)
        Me.COMPRechazados.Name = "COMPRechazados"
        Me.COMPRechazados.Size = New System.Drawing.Size(100, 20)
        Me.COMPRechazados.TabIndex = 10
        Me.COMPRechazados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(71, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Registros leídos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(71, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Registros integrados"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(71, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Registros rechazados"
        '
        'Cerrar
        '
        Me.Cerrar.Location = New System.Drawing.Point(202, 320)
        Me.Cerrar.Name = "Cerrar"
        Me.Cerrar.Size = New System.Drawing.Size(89, 27)
        Me.Cerrar.TabIndex = 14
        Me.Cerrar.Text = "Cerrar"
        Me.Cerrar.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(74, 259)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(143, 13)
        Me.TextBox1.TabIndex = 15
        '
        'Ejecutar
        '
        Me.Ejecutar.Location = New System.Drawing.Point(202, 277)
        Me.Ejecutar.Name = "Ejecutar"
        Me.Ejecutar.Size = New System.Drawing.Size(89, 27)
        Me.Ejecutar.TabIndex = 16
        Me.Ejecutar.Text = "Ejecutar"
        Me.Ejecutar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 373)
        Me.Controls.Add(Me.Ejecutar)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Cerrar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.COMPRechazados)
        Me.Controls.Add(Me.COMPIntegrados)
        Me.Controls.Add(Me.COMPLeidos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Rechazados)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Integrados)
        Me.Controls.Add(Me.Leidos)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Integración Clientes Sodatech - MS Dynamics GP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Leidos As System.Windows.Forms.TextBox
    Friend WithEvents Integrados As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Rechazados As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents COMPLeidos As System.Windows.Forms.TextBox
    Friend WithEvents COMPIntegrados As System.Windows.Forms.TextBox
    Friend WithEvents COMPRechazados As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Cerrar As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Ejecutar As System.Windows.Forms.Button

End Class
