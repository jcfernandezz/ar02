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
        Me.Leidos = New System.Windows.Forms.TextBox()
        Me.Integrados = New System.Windows.Forms.TextBox()
        Me.Rechazados = New System.Windows.Forms.TextBox()
        Me.COMPLeidos = New System.Windows.Forms.TextBox()
        Me.COMPIntegrados = New System.Windows.Forms.TextBox()
        Me.COMPRechazados = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PREPLeidos = New System.Windows.Forms.TextBox()
        Me.PREPIntegrados = New System.Windows.Forms.TextBox()
        Me.PREPRechazados = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Leidos
        '
        Me.Leidos.Location = New System.Drawing.Point(165, 13)
        Me.Leidos.Name = "Leidos"
        Me.Leidos.Size = New System.Drawing.Size(100, 20)
        Me.Leidos.TabIndex = 0
        '
        'Integrados
        '
        Me.Integrados.AcceptsReturn = True
        Me.Integrados.Location = New System.Drawing.Point(165, 40)
        Me.Integrados.Name = "Integrados"
        Me.Integrados.Size = New System.Drawing.Size(100, 20)
        Me.Integrados.TabIndex = 1
        '
        'Rechazados
        '
        Me.Rechazados.Location = New System.Drawing.Point(165, 67)
        Me.Rechazados.Name = "Rechazados"
        Me.Rechazados.Size = New System.Drawing.Size(100, 20)
        Me.Rechazados.TabIndex = 2
        '
        'COMPLeidos
        '
        Me.COMPLeidos.Location = New System.Drawing.Point(165, 126)
        Me.COMPLeidos.Name = "COMPLeidos"
        Me.COMPLeidos.Size = New System.Drawing.Size(100, 20)
        Me.COMPLeidos.TabIndex = 3
        '
        'COMPIntegrados
        '
        Me.COMPIntegrados.Location = New System.Drawing.Point(165, 153)
        Me.COMPIntegrados.Name = "COMPIntegrados"
        Me.COMPIntegrados.Size = New System.Drawing.Size(100, 20)
        Me.COMPIntegrados.TabIndex = 4
        '
        'COMPRechazados
        '
        Me.COMPRechazados.Location = New System.Drawing.Point(165, 180)
        Me.COMPRechazados.Name = "COMPRechazados"
        Me.COMPRechazados.Size = New System.Drawing.Size(100, 20)
        Me.COMPRechazados.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(305, 247)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Sodatech"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PREPLeidos
        '
        Me.PREPLeidos.Location = New System.Drawing.Point(167, 231)
        Me.PREPLeidos.Name = "PREPLeidos"
        Me.PREPLeidos.Size = New System.Drawing.Size(100, 20)
        Me.PREPLeidos.TabIndex = 7
        '
        'PREPIntegrados
        '
        Me.PREPIntegrados.Location = New System.Drawing.Point(169, 265)
        Me.PREPIntegrados.Name = "PREPIntegrados"
        Me.PREPIntegrados.Size = New System.Drawing.Size(100, 20)
        Me.PREPIntegrados.TabIndex = 8
        '
        'PREPRechazados
        '
        Me.PREPRechazados.Location = New System.Drawing.Point(170, 296)
        Me.PREPRechazados.Name = "PREPRechazados"
        Me.PREPRechazados.Size = New System.Drawing.Size(100, 20)
        Me.PREPRechazados.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(305, 287)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Valorpix"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(309, 201)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 30)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Integrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 366)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PREPRechazados)
        Me.Controls.Add(Me.PREPIntegrados)
        Me.Controls.Add(Me.PREPLeidos)
        Me.Controls.Add(Me.Button1)
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PREPLeidos As System.Windows.Forms.TextBox
    Friend WithEvents PREPIntegrados As System.Windows.Forms.TextBox
    Friend WithEvents PREPRechazados As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
