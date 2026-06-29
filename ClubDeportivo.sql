-- ============================================================
--  Script Base de Datos: ClubDeportivo
--  Sistema: Club Deportivo — PI Grupo 1
--  Desarrollo de Sistemas Orientado a Objetos 1° D
-- ============================================================

DROP DATABASE IF EXISTS ClubDeportivo;

CREATE DATABASE ClubDeportivo
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_spanish_ci;

USE ClubDeportivo;

-- ------------------------------------------------------------
-- Tabla: usuarios
-- ------------------------------------------------------------
CREATE TABLE IF NOT EXISTS usuarios (
    idUsuario  INT          AUTO_INCREMENT PRIMARY KEY,
    usuario    VARCHAR(50)  NOT NULL UNIQUE,
    contrasena VARCHAR(100) NOT NULL,
    nombre     VARCHAR(100) NOT NULL
);

INSERT INTO usuarios (usuario, contrasena, nombre)
VALUES ('admin', 'admin123', 'Administrador');

-- ------------------------------------------------------------
-- Tabla: socios
--   aptoFisico: 1 = presentó certificado, 0 = no presentó
-- ------------------------------------------------------------
CREATE TABLE IF NOT EXISTS socios (
    nroSocio              INT           AUTO_INCREMENT PRIMARY KEY,
    nombre                VARCHAR(100)  NOT NULL,
    apellido              VARCHAR(100)  NOT NULL,
    dni                   VARCHAR(15)   NOT NULL UNIQUE,
    estado                VARCHAR(20)   NOT NULL DEFAULT 'activo',
    aptoFisico            TINYINT(1)    NOT NULL DEFAULT 0,
    fechaVencimientoCuota DATE          NULL
);

-- ------------------------------------------------------------
-- Tabla: no_socios
-- ------------------------------------------------------------
CREATE TABLE IF NOT EXISTS no_socios (
    idNoSocio INT          AUTO_INCREMENT PRIMARY KEY,
    nombre    VARCHAR(100) NOT NULL,
    apellido  VARCHAR(100) NOT NULL,
    dni       VARCHAR(15)  NOT NULL UNIQUE
);

-- ------------------------------------------------------------
-- Tabla: profesores
-- ------------------------------------------------------------
CREATE TABLE IF NOT EXISTS profesores (
    nroProfesor     INT           AUTO_INCREMENT PRIMARY KEY,
    nombre          VARCHAR(100)  NOT NULL,
    apellido        VARCHAR(100)  NOT NULL,
    dni             VARCHAR(15)   NOT NULL UNIQUE,
    especialidad    VARCHAR(100)  NOT NULL,
    horarioAsignado VARCHAR(150)  NOT NULL,
    sueldo          DECIMAL(10,2) NOT NULL
);

INSERT INTO profesores (nombre, apellido, dni, especialidad, horarioAsignado, sueldo) VALUES
('Roberto',  'Fernández', '22111333', 'Musculación y Aparatos', 'Lunes a Viernes 08:00-14:00', 180000.00),
('Laura',    'Gómez',     '25444555', 'Natación',               'Martes y Jueves 09:00-13:00', 160000.00),
('Marcelo',  'Ríos',      '28666777', 'Aeróbica y Yoga',        'Lunes, Miércoles y Viernes 17:00-21:00', 155000.00);

-- ------------------------------------------------------------
-- Tabla: actividades  (cartilla de precios)
-- ------------------------------------------------------------
CREATE TABLE IF NOT EXISTS actividades (
    nroActividad INT            AUTO_INCREMENT PRIMARY KEY,
    nombre       VARCHAR(100)   NOT NULL,
    horario      VARCHAR(100)   NOT NULL,
    tipo         VARCHAR(20)    NOT NULL,   -- 'grupal' | 'individual'
    precio       DECIMAL(10,2)  NOT NULL
);

INSERT INTO actividades (nombre, horario, tipo, precio) VALUES
('Musculación',  'Lunes a Viernes 08:00-22:00',              'individual', 1500.00),
('Aparatos',     'Lunes a Viernes 08:00-22:00',              'individual', 1500.00),
('Natación',     'Martes y Jueves 09:00-11:00',              'grupal',     2000.00),
('Aeróbica',     'Lunes, Miércoles y Viernes 18:00-19:00',   'grupal',     1800.00),
('Yoga',         'Martes y Jueves 17:00-18:00',              'grupal',     1800.00);

-- ------------------------------------------------------------
-- Tabla: cuotas  (socios — cuota mensual)
-- ------------------------------------------------------------
CREATE TABLE IF NOT EXISTS cuotas (
    nroCuota         INT            AUTO_INCREMENT PRIMARY KEY,
    nroSocio         INT            NOT NULL,
    tipo             VARCHAR(20)    NOT NULL DEFAULT 'mensual',
    monto            DECIMAL(10,2)  NOT NULL,
    medioPago        VARCHAR(10)    NOT NULL DEFAULT 'efectivo',
    cantCuotas       INT            NOT NULL DEFAULT 1,
    fechaPago        DATE           NOT NULL,
    fechaVencimiento DATE           NOT NULL,
    estado           VARCHAR(20)    NOT NULL DEFAULT 'pagada',
    FOREIGN KEY (nroSocio) REFERENCES socios(nroSocio)
);

-- ------------------------------------------------------------
-- Tabla: carnets
-- ------------------------------------------------------------
CREATE TABLE IF NOT EXISTS carnets (
    nroCarnet        INT  AUTO_INCREMENT PRIMARY KEY,
    nroSocio         INT  NOT NULL,
    fechaEmision     DATE NOT NULL,
    fechaVencimiento DATE NOT NULL,
    FOREIGN KEY (nroSocio) REFERENCES socios(nroSocio)
);

-- ------------------------------------------------------------
-- Tabla: cobros_nosocio  (no socios — cobro por actividad)
-- ------------------------------------------------------------
CREATE TABLE IF NOT EXISTS cobros_nosocio (
    idCobro      INT            AUTO_INCREMENT PRIMARY KEY,
    idNoSocio    INT            NOT NULL,
    nroActividad INT            NOT NULL,
    monto        DECIMAL(10,2)  NOT NULL,
    medioPago    VARCHAR(10)    NOT NULL DEFAULT 'efectivo',
    cantCuotas   INT            NOT NULL DEFAULT 1,
    fechaCobro   DATE           NOT NULL,
    FOREIGN KEY (idNoSocio)    REFERENCES no_socios(idNoSocio),
    FOREIGN KEY (nroActividad) REFERENCES actividades(nroActividad)
);

-- ------------------------------------------------------------
-- SP: sp_ActualizarEstadoVencidos
--   Marca como 'vencido' a todos los socios cuya fecha de
--   vencimiento de cuota es anterior a la fecha actual.
--   Llamar antes de consultar o mostrar estados de socios.
-- ------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_ActualizarEstadoVencidos;
DELIMITER //
CREATE PROCEDURE sp_ActualizarEstadoVencidos()
BEGIN
    UPDATE socios
    SET estado = 'vencido'
    WHERE fechaVencimientoCuota < CURDATE()
      AND estado = 'activo';
END //
DELIMITER ;

-- ------------------------------------------------------------
-- SP: sp_ValidarLogin
-- ------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_ValidarLogin;
DELIMITER //
CREATE PROCEDURE sp_ValidarLogin(
    IN  p_usuario    VARCHAR(50),
    IN  p_contrasena VARCHAR(100),
    OUT p_resultado  INT
)
BEGIN
    SELECT COUNT(*) INTO p_resultado
    FROM usuarios
    WHERE usuario = p_usuario AND contrasena = p_contrasena;
END //
DELIMITER ;

-- ------------------------------------------------------------
-- SP: sp_RegistrarSocio
-- ------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_RegistrarSocio;
DELIMITER //
CREATE PROCEDURE sp_RegistrarSocio(
    IN  p_nombre     VARCHAR(100),
    IN  p_apellido   VARCHAR(100),
    IN  p_dni        VARCHAR(15),
    IN  p_aptoFisico TINYINT(1),
    OUT p_resultado  INT   -- 0=OK, 1=DNI duplicado
)
BEGIN
    IF EXISTS (SELECT 1 FROM socios WHERE dni = p_dni) THEN
        SET p_resultado = 1;
    ELSE
        INSERT INTO socios (nombre, apellido, dni, estado, aptoFisico)
        VALUES (p_nombre, p_apellido, p_dni, 'activo', p_aptoFisico);
        SET p_resultado = 0;
    END IF;
END //
DELIMITER ;

-- ------------------------------------------------------------
-- SP: sp_RegistrarNoSocio
-- ------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_RegistrarNoSocio;
DELIMITER //
CREATE PROCEDURE sp_RegistrarNoSocio(
    IN  p_nombre    VARCHAR(100),
    IN  p_apellido  VARCHAR(100),
    IN  p_dni       VARCHAR(15),
    OUT p_resultado INT
)
BEGIN
    IF EXISTS (SELECT 1 FROM no_socios WHERE dni = p_dni) THEN
        SET p_resultado = 1;
    ELSE
        INSERT INTO no_socios (nombre, apellido, dni)
        VALUES (p_nombre, p_apellido, p_dni);
        SET p_resultado = 0;
    END IF;
END //
DELIMITER ;

-- ------------------------------------------------------------
-- SP: sp_CobrarCuota  (socios — cuota mensual)
-- ------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_CobrarCuota;
DELIMITER //
CREATE PROCEDURE sp_CobrarCuota(
    IN p_nroSocio   INT,
    IN p_monto      DECIMAL(10,2),
    IN p_fechaPago  DATE,
    IN p_medioPago  VARCHAR(10),
    IN p_cantCuotas INT
)
BEGIN
    DECLARE v_vencimiento DATE;
    SET v_vencimiento = DATE_ADD(p_fechaPago, INTERVAL 1 MONTH);

    INSERT INTO cuotas (nroSocio, tipo, monto, medioPago, cantCuotas, fechaPago, fechaVencimiento, estado)
    VALUES (p_nroSocio, 'mensual', p_monto, p_medioPago, p_cantCuotas, p_fechaPago, v_vencimiento, 'pagada');

    INSERT INTO carnets (nroSocio, fechaEmision, fechaVencimiento)
    VALUES (p_nroSocio, p_fechaPago, v_vencimiento);

    UPDATE socios
    SET estado = 'activo', fechaVencimientoCuota = v_vencimiento
    WHERE nroSocio = p_nroSocio;
END //
DELIMITER ;

-- ------------------------------------------------------------
-- SP: sp_CobrarNoSocio  (no socios — cobro por actividad)
-- ------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_CobrarNoSocio;
DELIMITER //
CREATE PROCEDURE sp_CobrarNoSocio(
    IN p_idNoSocio    INT,
    IN p_nroActividad INT,
    IN p_monto        DECIMAL(10,2),
    IN p_medioPago    VARCHAR(10),
    IN p_cantCuotas   INT,
    IN p_fechaCobro   DATE
)
BEGIN
    INSERT INTO cobros_nosocio (idNoSocio, nroActividad, monto, medioPago, cantCuotas, fechaCobro)
    VALUES (p_idNoSocio, p_nroActividad, p_monto, p_medioPago, p_cantCuotas, p_fechaCobro);
END //
DELIMITER ;

-- ------------------------------------------------------------
-- Datos de ejemplo
-- ------------------------------------------------------------
INSERT INTO socios (nombre, apellido, dni, estado, aptoFisico, fechaVencimientoCuota)
VALUES
    ('Juan',   'García',   '30111222', 'activo',  1, CURDATE() + INTERVAL 10 DAY),
    ('María',  'López',    '28333444', 'activo',  1, CURDATE()),
    ('Carlos', 'Martínez', '35555666', 'vencido', 1, CURDATE() - INTERVAL 5 DAY);
