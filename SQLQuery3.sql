INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Edad, EstadoCivil, Direccion, Telefono, Correo)
VALUES ('Juan', 'Pérez', '1234567890', '1990-01-15', 32, 'Soltero', 'Calle 123, Ciudad', '1234567890', 'juan@example.com');

INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Edad, EstadoCivil, Direccion, Telefono, Correo)
VALUES ('María', 'Gómez', '2345678901', '1985-03-20', 37, 'Casado', 'Avenida 456, Otra Ciudad', '9876543210', 'maria@example.com');

INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Edad, EstadoCivil, Direccion, Telefono, Correo)
VALUES ('Juana', 'Rodriguez', '1234567891', '1999-03-22', 24, 'Soltero', 'Calle 123, Ciudad', '1234567899', 'juana@example.com');

INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Edad, EstadoCivil, Direccion, Telefono, Correo)
VALUES ('Paula', 'Salas', '1345678931', '1999-02-20', 24, 'Casado', 'Avenida 456, Otra Ciudad', '9876543211', 'salas@example.com');

select * from Pacientes



-- Insertar datos en la tabla "Facturas"
INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita)
VALUES ('2023-08-11', 150.00, 'Pendiente', 1, 2, 3);

INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita)
VALUES ('2023-08-12', 200.50, 'Pagado', 2, 1, 4);

INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita)
VALUES ('2023-08-13', 300.75, 'Pagado', 3, 2, 5);

INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita)
VALUES ('2023-08-14', 120.25, 'Pendiente', 1, 3, 6);

INSERT INTO Facturas (Fecha, MontoTotal, EstadoPago, idPaciente, idConsultorio, idCita)
VALUES ('2023-08-14', 120.25, 'Pendiente', 4, 3, 6);


select * from Facturas



-- insertar datos de Cita
