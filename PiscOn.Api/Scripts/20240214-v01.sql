DO $$ 
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM information_schema.tables
        WHERE table_schema = 'public'
        AND table_name = 'Contato'
    ) THEN
        CREATE TABLE "Contato" (
            "CodigoContato" serial,
            "Nome" varchar(255),
            "Celular" varchar(16),
            "CPF" varchar(14),
            "Email" varchar(255),
            CONSTRAINT "Contato_PK" PRIMARY KEY ("CodigoContato")
        );
    END IF;
END $$;
