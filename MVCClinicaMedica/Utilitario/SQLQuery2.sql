create database ClinicaDB;
use ClinicaDB;
INSERT INTO Especialidades (Descripcion) VALUES
('Cardiología'),
('Dermatología'),
('Gastroenterología'),
('Neurología');
INSERT INTO EquiposMedicos (NombreEquipo, DescripcionEquipo) VALUES
('Rayos X', 'Equipo para radiografías.'),
('Ecógrafo', 'Equipo de ultrasonido para diagnóstico médico.');
INSERT INTO Medicos (Nombre, Apellido, Telefono, Correo, Horario, idEspecialidad) VALUES
('Dr. Juan', 'Gómez', '123-456-7890', 'juan@example.com', '9:00 AM - 5:00 PM', 1),
('Dra. María', 'López', '987-654-3210', 'maria@example.com', '10:00 AM - 6:00 PM', 2),
('Dr. Pedro', 'Martínez', '567-890-1234', 'pedro@example.com', '8:00 AM - 4:00 PM', 3);
INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Edad, EstadoCivil, Direccion, Telefono, Correo,HistoriaClinica) VALUES
('Laura', 'Fernández', '4567890123', '1992-03-25', 29, 'Soltera', 'Calle 456', '111-222-3333', 'laura@example.com','diabetes'),
('Carlos', 'Ramírez', '5678901234', '1988-08-10', 33, 'Casado', 'Av. 789', '444-555-6666', 'carlos@example.com','presion alta'),
('Ana', 'López', '6789012345', '2000-01-05', 22, 'Soltera', 'Calle 789', '777-888-9999', 'ana@example.com','miopia');
INSERT INTO TiposPagos (Descripcion) VALUES
('Efectivo'),
('Tarjeta de crédito'),
('Transferencia');
INSERT INTO Citas (Fecha, idMedico, idTipoPago, idPaciente) VALUES
('2023-08-04', 1, 1, 1),
('2023-08-05', 1, 2, 1),
('2023-08-06', 1, 1, 2);
INSERT INTO Consultorios (PrecioConsulta, idMedico) VALUES
(100, 1),
(120, 2),
(90, 3);
INSERT INTO RegistrosMedicos (Descripcion, idPaciente) VALUES
('Registro médico de Laura Fernández', 1),
('Registro médico 2 de Laura Fernández', 1),
('Registro médico de Carlos Ramírez', 2),
('Registro médico de Ana López', 3);
INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita) VALUES
('2023-08-01', 100, 'Pendiente', 1, 1, 1),
('2023-08-02', 120, 'Pagado', 2, 2, 2),
('2023-08-03', 90, 'Pendiente', 3, 3, 3);
select * from Citas;