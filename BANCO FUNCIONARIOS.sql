CREATE TABLE Funcionarios (
    id INT IDENTITY(1,1) PRIMARY KEY, 
    ativo BIT NOT NULL, 
    nome VARCHAR(100) NOT NULL, 
    idade INT NOT NULL CHECK (idade > 0), 
    sexo CHAR(1) NOT NULL CHECK (sexo IN ('M', 'F')),
    cargo VARCHAR(50) NOT NULL, -- 
    salario DECIMAL(15,2) NOT NULL CHECK (salario >= 0), 
    departamento VARCHAR(100) NOT NULL -- 
);

select * from Funcionarios