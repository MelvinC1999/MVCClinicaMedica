select * from Citas

INSERT INTO Citas (Fecha, MedicosidMedico, idMedico, TiposPagosidTipoPago, idTipoPago, PacientesidPaciente, idPaciente)
VALUES ('2023-08-15 15:30:00', 6, 6, 1, 1, 3, 3); -- Reemplaza los valores según tus necesidades


select * from Medicos

-- Insertando tres registros de ejemplo en la tabla Medicos

-- Registro 1
INSERT INTO Medicos (Nombre, Apellido, Telefono, Correo, Horario, idEspecialidad)
VALUES ('Juan', 'Perez', '555-123-4567', 'juan.perez@example.com', 'Lunes', 1);

-- Registro 2
INSERT INTO Medicos (Nombre, Apellido, Telefono, Correo, Horario, idEspecialidad)
VALUES ('Maria', 'Gonzalez', '555-987-6543', 'maria.gonzalez@example.com', 'Martes', 2);

-- Registro 3
INSERT INTO Medicos (Nombre, Apellido, Telefono, Correo, Horario, idEspecialidad)
VALUES ('Carlos', 'Martinez', '555-555-5555', 'carlos.martinez@example.com', 'Lunes', 3);

INSERT INTO Medicos (Nombre, Apellido, Telefono, Correo, Horario, EspecialidadesidEspecialidad , idEspecialidad)
VALUES ('Carlos2', 'Martinez2', '555-555-5552', 'carlos.maez@example.com', 'Martess', 4, 4);
