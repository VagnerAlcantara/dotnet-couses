//using Dapper;
//using FrameWork.Data.WebServiceProxy;
//using System;
//using System.Data.Common;

//namespace  GerenciadorUsuarioService.Infra.SQL.SqlCommand
//{
//    public class LdapIdSqlCommand
//    {
//        public DbTransaction _transaction;
//        public string _sql = string.Empty;
//        internal CommandDefinition GetCommandInsert(Dominio.Entidades.Usuario usuario)
//        {
//            _sql = @"INSERT INTO [dbo].[LDAP_ID]
//                   ([IDarvore]
//                   ,[dt_imput]
//                   ,[EMAIL]
//                   ,[CN]
//                   ,[CPF]
//                   ,[RG]
//                   ,[SEXO]
//                   ,[DT_NASCIMENTO]
//                   ,[TELEPHONENUMBER]
//                   ,[CELLULARTELEPHONENUMBER]
//                   ,[HOMEPHONE]
//                   ,[STREET]
//                   ,[POSTALADDRESS]
//                   ,[POSTALCODE]
//                   ,[CIDADE]
//                   ,[ESTADO]
//                   ,[NUM_BANCO]
//                   ,[NUM_AGENCIA]
//                   ,[TIPO_CONTA]
//                   ,[NUM_CONTA]
//                   ,[DIG_CONTA]
//                   ,[FLAG_VINCULADO_FDE]
//                   ,[EMPLOYEETYPE]
//                   ,[GIVENNAME]
//                   ,[SN]
//                   ,[BUSINESSCATEGORY]
//                   ,[RS]
//                   ,[NUMEND]
//                   ,[COMPLNTO]
//                   ,[OEMISS]
//                   ,[UFEMISS]
//                   ,[DDDCEL]
//                   ,[DDDRES]
//                   ,[DDDCOM]
//                   ,[RAMALCO]
//                   ,[INSTORIG]
//                   ,[REGSERVI]
//                   ,[USERPASSWORD])
//             VALUES
//                   (@IDArvore
//                   ,@dt_imput
//                   ,@EMAIL
//                   ,@CN
//                   ,@CPF
//                   ,@RG
//                   ,@SEXO
//                   ,@DT_NASCIMENTO
//                   ,@TELEPHONENUMBER
//                   ,@CELLULARTELEPHONENUMBER
//                   ,@HOMEPHONE
//                   ,@STREET
//                   ,@POSTALADDRESS
//                   ,@POSTALCODE
//                   ,@CIDADE
//                   ,@ESTADO
//                   ,@NUM_BANCO
//                   ,@NUM_AGENCIA
//                   ,@TIPO_CONTA
//                   ,@NUM_CONTA
//                   ,@DIG_CONTA
//                   ,@FLAG_VINCULADO_FDE
//                   ,@EMPLOYEETYPE
//                   ,@GIVENNAME
//                   ,@SN
//                   ,@BUSINESSCATEGORY
//                   ,@RS
//                   ,@NUMEND
//                   ,@COMPLNTO
//                   ,@OEMISS
//                   ,@UFEMISS
//                   ,@DDDCEL
//                   ,@DDDRES
//                   ,@DDDCOM
//                   ,@RAMALCO
//                   ,@INSTORIG
//                   ,@REGSERVI
//                   ,@USERPASSWORD)

//                    SELECT  SCOPE_IDENTITY()";

//            object param = new
//            {
//                @IDArvore = usuario.IdArvore.HasValue ? usuario.IdArvore.Value : 0,
//                @dt_imput = DateTime.Now,
//                @EMAIL = usuario.Email,
//                @CN = usuario.Nome,
//                @CPF = usuario.CPF,
//                @RG = usuario.RG,
//                @SEXO = usuario.Sexo,
//                @DT_NASCIMENTO = usuario.DataNascimento,
//                @TELEPHONENUMBER = usuario.TelefoneComercial,
//                @CELLULARTELEPHONENUMBER = usuario.TelefoneCelular,
//                @HOMEPHONE = usuario.TelefoneResidencial,
//                @STREET = usuario.Logradouro,
//                @POSTALADDRESS = usuario.Bairro,
//                @POSTALCODE = usuario.CEP,
//                @CIDADE = usuario.Cidade,
//                @ESTADO = usuario.UF,
//                @NUM_BANCO = usuario.NumeroBanco,
//                @NUM_AGENCIA = usuario.Agencia,
//                @TIPO_CONTA = usuario.TipoConta,
//                @NUM_CONTA = usuario.NumeroConta,
//                @DIG_CONTA = usuario.Digito,
//                @FLAG_VINCULADO_FDE = usuario.VinculadoFDE,
//                @EMPLOYEETYPE = usuario.Cargo,
//                @GIVENNAME = usuario.PrimeironoNome,
//                @SN = usuario.Sobrenome,
//                @BUSINESSCATEGORY = usuario.Departamento,
//                @RS = string.Empty,
//                @NUMEND = usuario.Numero,
//                @COMPLNTO = usuario.Complemento,
//                @OEMISS = usuario.OrgaoExpedidor,
//                @UFEMISS = usuario.UfEmissor,
//                @DDDCEL = usuario.DddCelular,
//                @DDDRES = usuario.DddResidencial,
//                @DDDCOM = usuario.DddComercial,
//                @RAMALCO = usuario.Ramal,
//                @INSTORIG = usuario.Instituicao_Origem,
//                @REGSERVI = usuario.RegistroServidor,
//                @USERPASSWORD = new LDAPCripto().Criptografar(usuario.RG)
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandUpdate(Dominio.Entidades.Usuario usuario)
//        {
//            _sql = @"UPDATE [dbo].[LDAP_ID]
//                       SET [IDarvore] = @IDarvore
//                          ,[dt_imput] = @dt_imput
//                          ,[EMAIL] = @EMAIL
//                          ,[CN] = @CN
//                          ,[CPF] = @CPF
//                          ,[RG] = @RG
//                          ,[SEXO] = @SEXO
//                          ,[DT_NASCIMENTO] = @DT_NASCIMENTO
//                          ,[TELEPHONENUMBER] = @TELEPHONENUMBER
//                          ,[CELLULARTELEPHONENUMBER] = @CELLULARTELEPHONENUMBER
//                          ,[HOMEPHONE] = @HOMEPHONE
//                          ,[STREET] = @STREET
//                          ,[POSTALADDRESS] = @POSTALADDRESS
//                          ,[POSTALCODE] = @POSTALCODE
//                          ,[CIDADE] = @CIDADE
//                          ,[ESTADO] = @ESTADO
//                          ,[NUM_BANCO] = @NUM_BANCO
//                          ,[NUM_AGENCIA] = @NUM_AGENCIA
//                          ,[TIPO_CONTA] = @TIPO_CONTA
//                          ,[NUM_CONTA] = @NUM_CONTA
//                          ,[DIG_CONTA] = @DIG_CONTA
//                          ,[FLAG_VINCULADO_FDE] = @FLAG_VINCULADO_FDE
//                          ,[EMPLOYEETYPE] = @EMPLOYEETYPE
//                          ,[GIVENNAME] = @GIVENNAME
//                          ,[SN] = @SN
//                          ,[BUSINESSCATEGORY] = @BUSINESSCATEGORY
//                          ,[RS] = @RS
//                          ,[NUMEND] = @NUMEND
//                          ,[COMPLNTO] = @COMPLNTO
//                          ,[OEMISS] = @OEMISS
//                          ,[UFEMISS] = @UFEMISS
//                          ,[DDDCEL] = @DDDCEL
//                          ,[DDDRES] = @DDDRES
//                          ,[DDDCOM] = @DDDCOM
//                          ,[RAMALCO] = @RAMALCO
//                          ,[INSTORIG] = @INSTORIG
//                          ,[REGSERVI] = @REGSERVI
//                          --,[USERPASSWORD] = @USERPASSWORD
//                    WHERE 
//                           [ID_LDAP] = @IDLDAP";

//            object param = new
//            {
//                @IDLDAP = usuario.IDLDAP,
//                @IDarvore = usuario.IdArvore.HasValue ? usuario.IdArvore.Value : 0,
//                @dt_imput = DateTime.Now,
//                @EMAIL = usuario.Email,
//                @CN = usuario.Nome,
//                @CPF = usuario.CPF,
//                @RG = usuario.RG,
//                @SEXO = usuario.Sexo,
//                @DT_NASCIMENTO = usuario.DataNascimento,
//                @TELEPHONENUMBER = usuario.TelefoneComercial,
//                @CELLULARTELEPHONENUMBER = usuario.TelefoneCelular,
//                @HOMEPHONE = usuario.TelefoneResidencial,
//                @STREET = usuario.Logradouro,
//                @POSTALADDRESS = usuario.CEP,
//                @POSTALCODE = usuario.CEP,
//                @CIDADE = usuario.Cidade,
//                @ESTADO = usuario.UF,
//                @NUM_BANCO = usuario.NumeroBanco,
//                @NUM_AGENCIA = usuario.Agencia,
//                @TIPO_CONTA = usuario.TipoConta,
//                @NUM_CONTA = usuario.NumeroConta,
//                @DIG_CONTA = usuario.Digito,
//                @FLAG_VINCULADO_FDE = usuario.VinculadoFDE,
//                @EMPLOYEETYPE = usuario.Cargo,
//                @GIVENNAME = usuario.PrimeironoNome,
//                @SN = usuario.Sobrenome,
//                @BUSINESSCATEGORY = usuario.Departamento,
//                @RS = string.Empty,
//                @NUMEND = usuario.Numero,
//                @COMPLNTO = usuario.Complemento,
//                @OEMISS = usuario.OrgaoExpedidor,
//                @UFEMISS = usuario.UfEmissor,
//                @DDDCEL = usuario.DddCelular,
//                @DDDRES = usuario.DddResidencial,
//                @DDDCOM = usuario.DddComercial,
//                @RAMALCO = usuario.Ramal,
//                @INSTORIG = usuario.Instituicao_Origem,
//                @REGSERVI = usuario.RegistroServidor
//                //@USERPASSWORD =
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandResetarSenha(string idLdap, string cpf)
//        {
//            _sql = @"UPDATE [dbo].[LDAP_ID]
//                       SET [USERPASSWORD] = @CPFCRIPTOGRAFADO
//                    WHERE 
//                           [ID_LDAP] = @IDLDAP";

//            object param = new
//            {
//                @IDLDAP = idLdap,
//                @CPFCRIPTOGRAFADO = new LDAPCripto().Criptografar(cpf)
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandDelete(string idLdap)
//        {
//            _sql = @"DELETE 
//                        FROM [dbo].[LDAP_ID]
//                       WHERE [ID_LDAP] = @IDLDAP";

//            object param = new
//            {
//                IDLDAP = idLdap
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandValidaRgCpf(string rg, string cpf, string idLdap, string email)
//        {
//            _sql = @"
//                     DECLARE 
//                     @IDLDAPRGEXISTENTE	    VARCHAR(20) = NULL,
//		             @IDLDAPCPFEXISTENTE    VARCHAR(20) = NULL,
//		             @IDLDAPEMAILEXISTENTE  VARCHAR(20) = NULL,
//                     @ERRO		            VARCHAR(250) = NULL;
                     
//                    SELECT 
//                        @IDLDAPRGEXISTENTE = L.ID_LDAP 
//                     FROM 
//                        LDAP_ID L  WITH (NOLOCK)
//                     WHERE 
//                        L.RG = @RG 
//                     AND 
//                        (L.ID_LDAP <> @IDLDAP OR @IDLDAP IS NULL);

//                    SELECT 
//                        @IDLDAPEMAILEXISTENTE = L.ID_LDAP 
//                     FROM 
//                        LDAP_ID L WITH (NOLOCK)
//                     WHERE 
//                        L.EMAIL = @EMAIL 
//                     AND 
//                        (L.ID_LDAP <> @IDLDAP OR @IDLDAP IS NULL);
                    
//		            SELECT 
//                        @IDLDAPCPFEXISTENTE = L.ID_LDAP 
//                    FROM 
//                        LDAP_ID L WITH (NOLOCK)
//                    WHERE 
//                        L.CPF = @CPF 
//                    AND 
//                        (L.ID_LDAP <> @IDLDAP OR @IDLDAP IS NULL);

//					PRINT @IDLDAPRGEXISTENTE
//					PRINT @IDLDAPCPFEXISTENTE
//					PRINT @IDLDAPEMAILEXISTENTE
		
//					-- APENAS O RG COM ERRO
//					IF(@IDLDAPRGEXISTENTE IS NOT NULL AND @IDLDAPCPFEXISTENTE IS NULL AND @IDLDAPEMAILEXISTENTE IS NULL)
//					BEGIN
//						SET @ERRO = 'O RG informado já existe no sistema';
//					END
		
//					-- APENAS O E-MAIL COM ERRO
//					IF(@IDLDAPRGEXISTENTE IS NULL AND @IDLDAPCPFEXISTENTE IS NULL AND @IDLDAPEMAILEXISTENTE IS NOT NULL)
//					BEGIN
//						SET @ERRO = 'O E-mail informado já existe no sistema';
//					END
		            
//					-- APENAS O CPF COM ERRO
//					IF(@IDLDAPRGEXISTENTE IS NULL AND @IDLDAPCPFEXISTENTE IS NOT NULL AND @IDLDAPEMAILEXISTENTE IS NULL)
//					BEGIN
//						SET @ERRO = 'O CPF informado já existe no sistema';
//					END
					
//					-- RG E CPF COM ERRO
//					IF(@IDLDAPRGEXISTENTE IS NOT NULL AND @IDLDAPCPFEXISTENTE IS NOT NULL AND @IDLDAPEMAILEXISTENTE IS NULL)
//					BEGIN
//						SET @ERRO = 'O RG e o CPF informados já existem no sistema';
//					END
		
//					-- RG E E-MAIL COM ERRO
//					IF(@IDLDAPRGEXISTENTE IS NOT NULL AND @IDLDAPCPFEXISTENTE IS NULL AND @IDLDAPEMAILEXISTENTE IS NOT NULL)
//					BEGIN
//						SET @ERRO = 'O RG e o E-mail informados já existem no sistema';
//					END
		
//					-- CPF E E-MAIL COM ERRO
//					IF(@IDLDAPRGEXISTENTE IS NULL AND @IDLDAPCPFEXISTENTE IS NOT NULL AND @IDLDAPEMAILEXISTENTE IS NOT NULL)
//					BEGIN
//						SET @ERRO = 'O CPF e o E-mail informados já existem no sistema';
//					END
		                
//					IF(@IDLDAPRGEXISTENTE IS NOT NULL AND @IDLDAPCPFEXISTENTE IS NOT NULL AND @IDLDAPEMAILEXISTENTE IS NOT NULL)
//					BEGIN
//						SET @ERRO = 'O CPF, RG e o E-mail informados já existem no sistema';
//					END
                    
//                    IF(@IDLDAPRGEXISTENTE IS NOT NULL OR @IDLDAPCPFEXISTENTE IS NOT NULL OR @IDLDAPEMAILEXISTENTE IS NOT NULL)
//	                BEGIN
//                        RAISERROR(@ERRO, 16, 1)
//	                END"
//                ;

//            object param = new
//            {
//                @RG = rg,
//                @IDLDAP = idLdap,
//                @CPF = cpf,
//                @EMAIL = email
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);

//        }
//        internal CommandDefinition GetCommandAtualizarSenha(string idLdap, string senha)
//        {
//            _sql = @"UPDATE [dbo].[LDAP_ID]
//                       SET [USERPASSWORD] = @PASSWORD
//                    WHERE 
//                           [ID_LDAP] = @IDLDAP";

//            object param = new
//            {
//                @IDLDAP = idLdap,
//                @PASSWORD = senha
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }



//        internal CommandDefinition GetCommandSelectByIdLdap(string idLdap)
//        {
//            _sql = @"SELECT 
//                       [ID_LDAP]				AS IDLDAP
//                      ,[IDarvore]				AS IdArvore
//					  ,[ds_arvore]				AS Arvore
//					  ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as AdsPath
//                      ,[dt_imput]				
//                      ,[EMAIL]					AS Email
//                      ,[CN]						AS Nome
//                      ,[CPF]					AS CPF
//                      ,[RG]						AS RG
//                      ,[SEXO]					AS Sexo
//                      ,[DT_NASCIMENTO]			AS DataNascimento
//                      ,[TELEPHONENUMBER]		AS TelefoneComercial
//                      ,[CELLULARTELEPHONENUMBER] AS TelefoneCelular
//                      ,[HOMEPHONE]				AS TelefoneResidencial
//                      ,[STREET]					AS Logradouro
//                      ,[POSTALADDRESS]			AS Bairro
//                      ,[POSTALCODE]				AS CEP
//                      ,[CIDADE]					AS Cidade
//                      ,[ESTADO]					AS UF
//                      ,[NUM_BANCO]				AS NumeroBanco
//                      ,[NUM_AGENCIA]			AS Agencia
//                      ,[TIPO_CONTA]				AS TipoConta
//                      ,[NUM_CONTA]				AS NumeroConta
//                      ,[DIG_CONTA]				AS Digito
//                      ,[FLAG_VINCULADO_FDE]		AS VinculadoFDE
//                      ,[EMPLOYEETYPE]			AS Cargo
//                      ,[GIVENNAME]				AS PrimeironoNome
//                      ,[SN]						AS Sobrenome
//                      ,[BUSINESSCATEGORY]		AS Departamento	
//                      ,[RS]						AS RS
//                      ,[NUMEND]					AS Numero
//                      ,[COMPLNTO]				AS Complemento
//                      ,[OEMISS]					AS OrgaoExpedidor
//                      ,[UFEMISS]				AS UfEmissor
//                      ,[DDDCEL]					AS DddCelular
//                      ,[DDDRES]					AS DddResidencial
//                      ,[DDDCOM]					AS DddComercial
//                      ,[RAMALCO]				AS Ramal
//                      ,[INSTORIG]				AS Instituicao_Origem
//                      ,[REGSERVI]				AS RegistroServidor
//                     FROM 
//                       [dbo].[LDAP_ID] WITH (NOLOCK)
//					 INNER JOIN
//					   [dbo].[Arvore_LDAP] WITH (NOLOCK)
//					 ON 
//					   [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore
//                     WHERE 
//                       [ID_LDAP] = @IDLDAP";

//            object param = new
//            {
//                @IDLDAP = idLdap
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandSelectByCpf(string cpf)
//        {
//            _sql = @"SELECT 
//                       [ID_LDAP]				AS IDLDAP
//                      ,[IDarvore]				AS IdArvore
//					  ,[ds_arvore]				AS Arvore
//					  ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as AdsPath
//                      ,[dt_imput]				
//                      ,[EMAIL]					AS Email
//                      ,[CN]						AS Nome
//                      ,[CPF]					AS CPF
//                      ,[RG]						AS RG
//                      ,[SEXO]					AS Sexo
//                      ,[DT_NASCIMENTO]			AS DataNascimento
//                      ,[TELEPHONENUMBER]		AS TelefoneComercial
//                      ,[CELLULARTELEPHONENUMBER] AS TelefoneCelular
//                      ,[HOMEPHONE]				AS TelefoneResidencial
//                      ,[STREET]					AS Logradouro
//                      ,[POSTALADDRESS]			AS Bairro
//                      ,[POSTALCODE]				AS CEP
//                      ,[CIDADE]					AS Cidade
//                      ,[ESTADO]					AS UF
//                      ,[NUM_BANCO]				AS NumeroBanco
//                      ,[NUM_AGENCIA]			AS Agencia
//                      ,[TIPO_CONTA]				AS TipoConta
//                      ,[NUM_CONTA]				AS NumeroConta
//                      ,[DIG_CONTA]				AS Digito
//                      ,[FLAG_VINCULADO_FDE]		AS VinculadoFDE
//                      ,[EMPLOYEETYPE]			AS Cargo
//                      ,[GIVENNAME]				AS PrimeironoNome
//                      ,[SN]						AS Sobrenome
//                      ,[BUSINESSCATEGORY]		AS Departamento	
//                      ,[RS]						AS RS
//                      ,[NUMEND]					AS Numero
//                      ,[COMPLNTO]				AS Complemento
//                      ,[OEMISS]					AS OrgaoExpedidor
//                      ,[UFEMISS]				AS UfEmissor
//                      ,[DDDCEL]					AS DddCelular
//                      ,[DDDRES]					AS DddResidencial
//                      ,[DDDCOM]					AS DddComercial
//                      ,[RAMALCO]				AS Ramal
//                      ,[INSTORIG]				AS Instituicao_Origem
//                      ,[REGSERVI]				AS RegistroServidor
//                     FROM 
//                       [dbo].[LDAP_ID] WITH (NOLOCK)
//					 INNER JOIN
//					   [dbo].[Arvore_LDAP] WITH (NOLOCK)
//					 ON 
//					   [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore
//                     WHERE 
//                       [CPF] = @CPF";

//            object param = new
//            {
//                @CPF = cpf
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandSelectByNameWithPassword(string name)
//        {
//            _sql = @"SELECT 
//                       [ID_LDAP]				AS IDLDAP
//                      ,[IDarvore]				AS IdArvore
//					  ,[ds_arvore]				AS Arvore
//					  ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as AdsPath
//                      ,[dt_imput]				
//                      ,[EMAIL]					AS Email
//                      ,[CN]						AS Nome
//                      ,[CPF]					AS CPF
//                      ,[RG]						AS RG
//                      ,[SEXO]					AS Sexo
//                      ,[DT_NASCIMENTO]			AS DataNascimento
//                      ,[TELEPHONENUMBER]		AS TelefoneComercial
//                      ,[CELLULARTELEPHONENUMBER] AS TelefoneCelular
//                      ,[HOMEPHONE]				AS TelefoneResidencial
//                      ,[STREET]					AS Logradouro
//                      ,[POSTALADDRESS]			AS Bairro
//                      ,[POSTALCODE]				AS CEP
//                      ,[CIDADE]					AS Cidade
//                      ,[ESTADO]					AS UF
//                      ,[NUM_BANCO]				AS NumeroBanco
//                      ,[NUM_AGENCIA]			AS Agencia
//                      ,[TIPO_CONTA]				AS TipoConta
//                      ,[NUM_CONTA]				AS NumeroConta
//                      ,[DIG_CONTA]				AS Digito
//                      ,[FLAG_VINCULADO_FDE]		AS VinculadoFDE
//                      ,[EMPLOYEETYPE]			AS Cargo
//                      ,[GIVENNAME]				AS PrimeironoNome
//                      ,[SN]						AS Sobrenome
//                      ,[BUSINESSCATEGORY]		AS Departamento	
//                      ,[RS]						AS RS
//                      ,[NUMEND]					AS Numero
//                      ,[COMPLNTO]				AS Complemento
//                      ,[OEMISS]					AS OrgaoExpedidor
//                      ,[UFEMISS]				AS UfEmissor
//                      ,[DDDCEL]					AS DddCelular
//                      ,[DDDRES]					AS DddResidencial
//                      ,[DDDCOM]					AS DddComercial
//                      ,[RAMALCO]				AS Ramal
//                      ,[INSTORIG]				AS Instituicao_Origem
//                      ,[REGSERVI]				AS RegistroServidor
//                      ,[USERPASSWORD]           AS Senha
//                     FROM 
//                       [dbo].[LDAP_ID] WITH (NOLOCK)
//					 INNER JOIN
//					   [dbo].[Arvore_LDAP] WITH (NOLOCK)
//					 ON 
//					   [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore
//                     WHERE 
//	                    [CN] = @NAME";

//            object param = new
//            {
//                @NAME = name,
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandSelectByCpfWithPassword(string cpf)
//        {
//            _sql = @"SELECT 
//                       [ID_LDAP]				AS IDLDAP
//                      ,[CN]						AS Nome
//                      ,[CPF]					AS CPF
//                      ,[USERPASSWORD]           AS Senha
//                     FROM 
//                       [dbo].[LDAP_ID] WITH (NOLOCK)
//					 INNER JOIN
//					   [dbo].[Arvore_LDAP] WITH (NOLOCK)
//					 ON 
//					   [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore
//                     WHERE 
//	                    [CPF] = @CPF";

//            object param = new
//            {
//                @CPF = cpf,
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandSelectFiltro(Dominio.Entidades.Usuario usuario)
//        {
//            _sql = @"SELECT 
//                       [ID_LDAP]				AS IDLDAP
//                      ,[IDarvore]				AS IdArvore
//					  ,[ds_arvore]				AS Arvore
//					  ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as AdsPath
//                      ,[dt_imput]				
//                      ,[EMAIL]					AS Email
//                      ,[CN]						AS Nome
//                      ,[CPF]					AS CPF
//                      ,[RG]						AS RG
//                      ,[SEXO]					AS Sexo
//                      ,[DT_NASCIMENTO]			AS DataNascimento
//                      ,[TELEPHONENUMBER]		AS TelefoneComercial
//                      ,[CELLULARTELEPHONENUMBER] AS TelefoneCelular
//                      ,[HOMEPHONE]				AS TelefoneResidencial
//                      ,[STREET]					AS Logradouro
//                      ,[POSTALADDRESS]			AS Bairro
//                      ,[POSTALCODE]				AS CEP
//                      ,[CIDADE]					AS Cidade
//                      ,[ESTADO]					AS UF
//                      ,[NUM_BANCO]				AS NumeroBanco
//                      ,[NUM_AGENCIA]			AS Agencia
//                      ,[TIPO_CONTA]				AS TipoConta
//                      ,[NUM_CONTA]				AS NumeroConta
//                      ,[DIG_CONTA]				AS Digito
//                      ,[FLAG_VINCULADO_FDE]		AS VinculadoFDE
//                      ,[EMPLOYEETYPE]			AS Cargo
//                      ,[GIVENNAME]				AS PrimeironoNome
//                      ,[SN]						AS Sobrenome
//                      ,[BUSINESSCATEGORY]		AS Departamento	
//                      ,[RS]						AS RS
//                      ,[NUMEND]					AS Numero
//                      ,[COMPLNTO]				AS Complemento
//                      ,[OEMISS]					AS OrgaoExpedidor
//                      ,[UFEMISS]				AS UfEmissor
//                      ,[DDDCEL]					AS DddCelular
//                      ,[DDDRES]					AS DddResidencial
//                      ,[DDDCOM]					AS DddComercial
//                      ,[RAMALCO]				AS Ramal
//                      ,[INSTORIG]				AS Instituicao_Origem
//                      ,[REGSERVI]				AS RegistroServidor
//                     FROM 
//                       [dbo].[LDAP_ID] WITH (NOLOCK)
//					 INNER JOIN
//					   [dbo].[Arvore_LDAP] WITH (NOLOCK)
//					 ON 
//					   [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore
//                     WHERE 
//	                    ([CN] LIKE @NOME OR @NOME IS NULL)
//                      AND
//	                    ([ID_LDAP] = @IDLDAP OR @IDLDAP IS NULL)
//                      AND
//	                    ([RG] LIKE @RG OR @RG IS NULL)
//                      AND
//	                    ([CPF] LIKE @CPF OR @CPF IS NULL)
//                      AND
//	                    ([EMAIL] LIKE @EMAIL OR @EMAIL IS NULL)
//                      AND
//                        ([IDarvore] = @IDARVORE OR @IDARVORE IS NULL)";


//            object param = new
//            {
//                @NOME = string.IsNullOrEmpty(usuario.Nome) ? null : string.Concat("%", usuario.Nome, "%"),
//                @Email = string.IsNullOrEmpty(usuario.Email) ? null : string.Concat("%", usuario.Email, "%"),
//                @IDLDAP = string.IsNullOrEmpty(usuario.IDLDAP) ? null : usuario.IDLDAP,
//                @RG = string.IsNullOrEmpty(usuario.RG) ? null : string.Concat("%", usuario.RG, "%"),
//                @CPF = string.IsNullOrEmpty(usuario.CPF) ? null : string.Concat("%", usuario.CPF, "%"),
//                @IDARVORE = usuario.IdArvore.HasValue ? usuario.IdArvore : null
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandSelectFiltroWithPassword(Dominio.Entidades.Usuario usuario)
//        {
//            _sql = @"SELECT 
//                       [ID_LDAP]				AS IDLDAP
//                      ,[IDarvore]				AS IdArvore
//					  ,[ds_arvore]				AS Arvore
//					  ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as AdsPath
//                      ,[dt_imput]				
//                      ,[EMAIL]					AS Email
//                      ,[CN]						AS Nome
//                      ,[CPF]					AS CPF
//                      ,[RG]						AS RG
//                      ,[SEXO]					AS Sexo
//                      ,[DT_NASCIMENTO]			AS DataNascimento
//                      ,[TELEPHONENUMBER]		AS TelefoneComercial
//                      ,[CELLULARTELEPHONENUMBER] AS TelefoneCelular
//                      ,[HOMEPHONE]				AS TelefoneResidencial
//                      ,[STREET]					AS Logradouro
//                      ,[POSTALADDRESS]			AS Bairro
//                      ,[POSTALCODE]				AS CEP
//                      ,[CIDADE]					AS Cidade
//                      ,[ESTADO]					AS UF
//                      ,[NUM_BANCO]				AS NumeroBanco
//                      ,[NUM_AGENCIA]			AS Agencia
//                      ,[TIPO_CONTA]				AS TipoConta
//                      ,[NUM_CONTA]				AS NumeroConta
//                      ,[DIG_CONTA]				AS Digito
//                      ,[FLAG_VINCULADO_FDE]		AS VinculadoFDE
//                      ,[EMPLOYEETYPE]			AS Cargo
//                      ,[GIVENNAME]				AS PrimeironoNome
//                      ,[SN]						AS Sobrenome
//                      ,[BUSINESSCATEGORY]		AS Departamento	
//                      ,[RS]						AS RS
//                      ,[NUMEND]					AS Numero
//                      ,[COMPLNTO]				AS Complemento
//                      ,[OEMISS]					AS OrgaoExpedidor
//                      ,[UFEMISS]				AS UfEmissor
//                      ,[DDDCEL]					AS DddCelular
//                      ,[DDDRES]					AS DddResidencial
//                      ,[DDDCOM]					AS DddComercial
//                      ,[RAMALCO]				AS Ramal
//                      ,[INSTORIG]				AS Instituicao_Origem
//                      ,[REGSERVI]				AS RegistroServidor
//                      ,[USERPASSWORD]           AS Senha
//                     FROM 
//                       [dbo].[LDAP_ID] WITH (NOLOCK)
//					 INNER JOIN
//					   [dbo].[Arvore_LDAP] WITH (NOLOCK)
//					 ON 
//					   [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore
//                     WHERE 
//	                    ([CN] = @NOME OR @NOME IS NULL)
//                      AND
//	                    ([ID_LDAP] = @IDLDAP OR @IDLDAP IS NULL)
//                      AND
//	                    ([RG] = @RG OR @RG IS NULL)
//                      AND
//	                    ([CPF] = @CPF OR @CPF IS NULL)
//                      AND
//                        ([IDarvore] = @IDARVORE OR @IDARVORE IS NULL)";

//            object param = new
//            {
//                @NOME = string.IsNullOrEmpty(usuario.Nome) ? null : usuario.Nome,
//                @IDLDAP = String.IsNullOrEmpty(usuario.IDLDAP) ? null : usuario.IDLDAP,
//                @RG = String.IsNullOrEmpty(usuario.RG) ? null : usuario.RG,
//                @CPF = String.IsNullOrEmpty(usuario.CPF) ? null : usuario.CPF,
//                @IDARVORE = usuario.IdArvore.HasValue ? usuario.IdArvore : null
//            };


//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }
//        internal CommandDefinition GetCommandSelectFiltro(Dominio.Entidades.Usuario usuario, GerenciadorUsuarioService.Dominio.Entidades.Op operador)
//        {
//            string operadorAndOr = string.Empty;

//            if (operador == Dominio.Entidades.Op.AND)
//                operadorAndOr = "AND";
//            else
//                operadorAndOr = "OR";

//            _sql = @"SELECT 
//                       [ID_LDAP]				AS IDLDAP
//                      ,[IDarvore]				AS IdArvore
//					  ,[ds_arvore]				AS Arvore
//					  ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as AdsPath
//                      ,[dt_imput]				
//                      ,[EMAIL]					AS Email
//                      ,[CN]						AS Nome
//                      ,[CPF]					AS CPF
//                      ,[RG]						AS RG
//                      ,[SEXO]					AS Sexo
//                      ,[DT_NASCIMENTO]			AS DataNascimento
//                      ,[TELEPHONENUMBER]		AS TelefoneComercial
//                      ,[CELLULARTELEPHONENUMBER] AS TelefoneCelular
//                      ,[HOMEPHONE]				AS TelefoneResidencial
//                      ,[STREET]					AS Logradouro
//                      ,[POSTALADDRESS]			AS Bairro
//                      ,[POSTALCODE]				AS CEP
//                      ,[CIDADE]					AS Cidade
//                      ,[ESTADO]					AS UF
//                      ,[NUM_BANCO]				AS NumeroBanco
//                      ,[NUM_AGENCIA]			AS Agencia
//                      ,[TIPO_CONTA]				AS TipoConta
//                      ,[NUM_CONTA]				AS NumeroConta
//                      ,[DIG_CONTA]				AS Digito
//                      ,[FLAG_VINCULADO_FDE]		AS VinculadoFDE
//                      ,[EMPLOYEETYPE]			AS Cargo
//                      ,[GIVENNAME]				AS PrimeironoNome
//                      ,[SN]						AS Sobrenome
//                      ,[BUSINESSCATEGORY]		AS Departamento	
//                      ,[RS]						AS RS
//                      ,[NUMEND]					AS Numero
//                      ,[COMPLNTO]				AS Complemento
//                      ,[OEMISS]					AS OrgaoExpedidor
//                      ,[UFEMISS]				AS UfEmissor
//                      ,[DDDCEL]					AS DddCelular
//                      ,[DDDRES]					AS DddResidencial
//                      ,[DDDCOM]					AS DddComercial
//                      ,[RAMALCO]				AS Ramal
//                      ,[INSTORIG]				AS Instituicao_Origem
//                      ,[REGSERVI]				AS RegistroServidor
//                     FROM 
//                       [dbo].[LDAP_ID] WITH (NOLOCK)
//					 INNER JOIN
//					   [dbo].[Arvore_LDAP] WITH (NOLOCK)
//					 ON 
//					   [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore
//                     WHERE 
//	                    ([CN] LIKE @NOME OR @NOME IS NULL)
//                      @OP
//	                    ([ID_LDAP] = @IDLDAP OR @IDLDAP IS NULL)
//                      @OP
//	                    ([RG] LIKE @RG OR @RG IS NULL)
//                      @OP
//	                    ([CPF] LIKE @CPF OR @CPF IS NULL)
//                      @OP
//                        ([IDarvore] = @IDARVORE OR @IDARVORE IS NULL)";




//            object param = new
//            {
//                @NOME = string.IsNullOrEmpty(usuario.Nome) ? null : string.Concat("%", usuario.Nome, "%"),
//                @IDLDAP = String.IsNullOrEmpty(usuario.IDLDAP) ? null : usuario.IDLDAP,
//                @RG = string.IsNullOrEmpty(usuario.RG) ? null : string.Concat("%", usuario.RG, "%"),
//                @CPF = string.IsNullOrEmpty(usuario.CPF) ? null : string.Concat("%", usuario.CPF, "%"),
//                @IDARVORE = usuario.IdArvore.HasValue ? usuario.IdArvore : null
//            };

//            _sql = _sql.Replace("@OP", operadorAndOr);

//            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
//        }

//    }
//}
