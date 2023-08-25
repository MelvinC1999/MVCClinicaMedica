Insert into Roles(NombreRol) values ('Paciente');
Insert into Roles(NombreRol) values ('Doctor');
Insert into Roles(NombreRol) values ('Administrador');

Insert into Operaciones(NombreOperacion) values ('Consulta');
Insert into Operaciones(NombreOperacion) values ('Registro');
Insert into Operaciones(NombreOperacion) values ('Administrador');
Select * from Roles;
Select * from Operaciones;

--Pacientes
Insert into Rol_Operaciones(idRol, idOperacion) values (1,1);
--Medico
Insert into Rol_Operaciones(idRol, idOperacion) values (2,1);
Insert into Rol_Operaciones(idRol, idOperacion) values (2,2);
--Administrador
Insert into Rol_Operaciones(idRol, idOperacion) values (3,1);
Insert into Rol_Operaciones(idRol, idOperacion) values (3,2);
Insert into Rol_Operaciones(idRol, idOperacion) values (3,3);
-- Insertar especialidades
INSERT INTO Especialidades (Descripcion) VALUES ('Cardiología'); -- Especialidad médica centrada en enfermedades del corazón y sistema circulatorio
INSERT INTO Especialidades (Descripcion) VALUES ('Dermatología'); -- Especialidad médica enfocada en trastornos de la piel, cabello y uñas
INSERT INTO Especialidades (Descripcion) VALUES ('Radiología'); -- Especialidad médica que utiliza imágenes para diagnosticar y tratar enfermedades

-- Insertar médicos
INSERT INTO Medicos (Nombre, Apellido, Telefono, Correo, Horario, idEspecialidad)
VALUES ('Nicole', 'Cedeño', '123456789', 'nicole@email.com', '9 AM - 5 PM', 1); -- Cardióloga
INSERT INTO Medicos (Nombre, Apellido, Telefono, Correo, Horario, idEspecialidad)
VALUES ('Carlos', 'Martínez', '987654321', 'carlos@email.com', '10 AM - 6 PM', 2); -- Dermatólogo
INSERT INTO Medicos (Nombre, Apellido, Telefono, Correo, Horario, idEspecialidad)
VALUES ('María', 'López', '555888999', 'maria@email.com', '8 AM - 4 PM', 3); -- Radióloga

-- Insertar pacientes

INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Edad, EstadoCivil, Direccion, Telefono, Correo, HistoriaClinica)
VALUES ('Juan', 'Pérez', '1234567890', '1995-05-10', 28, 'Soltero', 'Calle 123', '111222333', 'juan@email.com', 'Historia clínica detallada de Juan Pérez. Ha sido diagnosticado con hipertensión y está en tratamiento. Se recomienda seguimiento regular.'); -- Joven adulto

INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Edad, EstadoCivil, Direccion, Telefono, Correo, HistoriaClinica)
VALUES ('Ana', 'Gómez', '9876543210', '2002-11-15', 21, 'Soltera', 'Avenida ABC', '555444333', 'ana@email.com', 'Historia clínica de Ana Gómez. Paciente sana con exámenes de rutina y seguimiento preventivo.'); -- Joven adulto

INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Edad, EstadoCivil, Direccion, Telefono, Correo, HistoriaClinica)
VALUES ('Pedro', 'Ramírez', '5432167890', '1978-08-22', 45, 'Casado', 'Calle Siempre Viva', '777888999', 'pedro@email.com', 'Historia clínica completa de Pedro Ramírez. Ha tenido problemas respiratorios en el pasado y ha sido sometido a cirugía de apendicitis en 2020.'); -- Adulto


-- Insertar tipos de pagos
INSERT INTO TiposPagos (Descripcion) VALUES ('Efectivo'); -- Pago en efectivo
INSERT INTO TiposPagos (Descripcion) VALUES ('Tarjeta de Crédito'); -- Pago con tarjeta de crédito
INSERT INTO TiposPagos (Descripcion) VALUES ('Transferencia Bancaria'); -- Pago por transferencia
INSERT INTO TiposPagos (Descripcion) VALUES ('Tarjeta de Débito'); -- Pago con tarjeta de débito

-- Insertar consultorios
INSERT INTO Consultorios (PrecioConsulta, idMedico)
VALUES (60.00, 1); -- Consultorio para cardiología
INSERT INTO Consultorios (PrecioConsulta, idMedico)
VALUES (50.00, 2); -- Consultorio para dermatología
INSERT INTO Consultorios (PrecioConsulta, idMedico)
VALUES (40.00, 3); -- Consultorio para radiología

-- Insertar equipos médicos
INSERT INTO EquiposMedicos (NombreEquipo, DescripcionEquipo)
VALUES ('ECG', 'Electrocardiograma'); -- Equipo para realizar ECG
INSERT INTO EquiposMedicos (NombreEquipo, DescripcionEquipo)
VALUES ('RX', 'Radiografía'); -- Equipo para radiografías
INSERT INTO EquiposMedicos (NombreEquipo, DescripcionEquipo)
VALUES ('US', 'Ultrasonido'); -- Equipo para ultrasonidos
INSERT INTO EquiposMedicos (NombreEquipo, DescripcionEquipo)
VALUES ('DTC', 'Dermatoscopio'); -- Equipo para dermatoscopía

-- Insertar asignación de equipos a consultorios
INSERT INTO EquiposMedicosConsultorios (idEquipo, idConsultorio)
VALUES (1, 1); -- Asignar ECG al consultorio de cardiología
INSERT INTO EquiposMedicosConsultorios (idEquipo, idConsultorio)
VALUES (2, 3); -- Asignar RX al consultorio de radiología
INSERT INTO EquiposMedicosConsultorios (idEquipo, idConsultorio)
VALUES (3, 3); -- Asignar US al consultorio de radiología
INSERT INTO EquiposMedicosConsultorios (idEquipo, idConsultorio)
VALUES (4, 2); -- Asignar DTC al consultorio de dermatología

-- Insertar citas
INSERT INTO Citas (Fecha, idMedico, idTipoPago, idPaciente)
VALUES ('2023-08-20', 1, 2, 1); -- Cita con cardióloga para Juan
INSERT INTO Citas (Fecha, idMedico, idTipoPago, idPaciente)
VALUES ('2023-08-22', 2, 3, 2); -- Cita con dermatólogo para Ana
INSERT INTO Citas (Fecha, idMedico, idTipoPago, idPaciente)
VALUES ('2023-08-25', 3, 1, 3); -- Cita con radióloga para Pedro

-- Insertar facturas
INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita)
VALUES ('2023-08-21', 150.00, 'Pagado', 1, 1, 1); -- Factura por cita de Juan con cardióloga
INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita)
VALUES ('2023-08-23', 200.00, 'Pendiente', 2, 2, 2); -- Factura por cita de Ana con dermatólogo
INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita)
VALUES ('2023-08-26', 180.00, 'Pendiente', 3, 3, 3); -- Factura por cita de Pedro con radióloga

-- Insertar registros en la tabla RegistrosMedicos
INSERT INTO RegistrosMedicos (Descripcion, Fecha, idPaciente) VALUES ('Examen de sangre', '2023-08-19', 2);
INSERT INTO RegistrosMedicos (Descripcion, Fecha, idPaciente) VALUES ('Radiografía de tórax', '2023-08-21', 1);
INSERT INTO RegistrosMedicos (Descripcion, Fecha, idPaciente) VALUES ('Consulta de seguimiento', '2023-08-23', 3);



