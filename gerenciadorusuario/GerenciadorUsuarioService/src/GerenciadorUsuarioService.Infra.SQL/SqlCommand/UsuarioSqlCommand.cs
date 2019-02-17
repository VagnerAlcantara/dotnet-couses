using Dapper;
using FrameWork.Data.WebServiceProxy;
using GerenciadorUsuarioService.Dominio.Entidades;
using GerenciadorUsuarioService.Infra.SQL.Interfaces;
using System;
using System.Data;
using System.Text;

namespace GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class UsuarioSqlCommand : IUsuarioSqlCommand
    {
        #region| Select Properties
        private StringBuilder _sqlSelect = new StringBuilder(
                    @"SELECT
                       [ID_LDAP]    AS IDLDAP
                      ,[IDarvore]   AS IdArvore
                      ,[ds_arvore]              AS Arvore
                      ,(SUBSTRING(ds_arvore, 0, (SELECT CHARINDEX(',o=', ds_arvore)))) as AdsPath
                      ,[dt_imput]				
                      ,[EMAIL]                      AS Email
                      ,[CN]                         AS Nome
                      ,[CPF]                        AS CPF
                      ,[RG]                         AS RG
                      ,[SEXO]                       AS Sexo
                      ,[DT_NASCIMENTO]              AS DataNascimento
                      ,[TELEPHONENUMBER]            AS TelefoneComercial
                      ,[CELLULARTELEPHONENUMBER]    AS TelefoneCelular
                      ,[HOMEPHONE]                  AS TelefoneResidencial
                      ,[STREET]                     AS Logradouro
                      ,[POSTALADDRESS]              AS Bairro
                      ,[POSTALCODE]                 AS CEP
                      ,[CIDADE]                     AS Cidade
                      ,[ESTADO]                     AS UF
                      ,[NUM_BANCO]                  AS NumeroBanco
                      ,[NUM_AGENCIA]                AS Agencia
                      ,[TIPO_CONTA]                 AS TipoConta
                      ,[NUM_CONTA]                  AS NumeroConta
                      ,[DIG_CONTA]                  AS Digito
                      ,[FLAG_VINCULADO_FDE]         AS VinculadoFDE
                      ,[EMPLOYEETYPE]               AS Cargo
                      ,[GIVENNAME]                  AS PrimeironoNome
                      ,[SN]                         AS Sobrenome
                      ,[BUSINESSCATEGORY]           AS Departamento
                      ,[RS]                         AS RS
                      ,[NUMEND]                     AS Numero
                      ,[COMPLNTO]                   AS Complemento
                      ,[OEMISS]                     AS OrgaoExpedidor
                      ,[UFEMISS]                    AS UfEmissor
                      ,[DDDCEL]                     AS DddCelular
                      ,[DDDRES]                     AS DddResidencial
                      ,[DDDCOM]                     AS DddComercial
                      ,[RAMALCO]                    AS Ramal
                      ,[INSTORIG]                   AS Instituicao_Origem
                      ,[REGSERVI]                   AS RegistroServidor
                      ,[EMAIL_SERVIDOR]             AS EmailServidor
                      ,[EMAIL_PROFESSOR]            AS EmailProfessor
                     FROM
                       [dbo].[LDAP_ID]      WITH(NOLOCK)
                     INNER JOIN
                       [dbo].[Arvore_LDAP]  WITH(NOLOCK)    ON  [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore ");


        private StringBuilder _sqlSelectWithPassword = new StringBuilder(
                    @"SELECT
                       [ID_LDAP]                    AS IDLDAP
                      ,[IDarvore]                   AS IdArvore
                      ,[ds_arvore]                  AS Arvore
                      ,(SUBSTRING(ds_arvore, 0, (SELECT CHARINDEX(',o=', ds_arvore)))) as AdsPath
                      ,[dt_imput]				
                      ,[EMAIL]                      AS Email
                      ,[CN]                         AS Nome
                      ,[CPF]                        AS CPF
                      ,[RG]                         AS RG
                      ,[SEXO]                       AS Sexo
                      ,[DT_NASCIMENTO]              AS DataNascimento
                      ,[TELEPHONENUMBER]            AS TelefoneComercial
                      ,[CELLULARTELEPHONENUMBER]    AS TelefoneCelular
                      ,[HOMEPHONE]                  AS TelefoneResidencial
                      ,[STREET]                     AS Logradouro
                      ,[POSTALADDRESS]              AS Bairro
                      ,[POSTALCODE]                 AS CEP
                      ,[CIDADE]                     AS Cidade
                      ,[ESTADO]                     AS UF
                      ,[NUM_BANCO]                  AS NumeroBanco
                      ,[NUM_AGENCIA]                AS Agencia
                      ,[TIPO_CONTA]                 AS TipoConta
                      ,[NUM_CONTA]                  AS NumeroConta
                      ,[DIG_CONTA]                  AS Digito
                      ,[FLAG_VINCULADO_FDE]         AS VinculadoFDE
                      ,[EMPLOYEETYPE]               AS Cargo
                      ,[GIVENNAME]                  AS PrimeironoNome
                      ,[SN]                         AS Sobrenome
                      ,[BUSINESSCATEGORY]           AS Departamento
                      ,[RS]                         AS RS
                      ,[NUMEND]                     AS Numero
                      ,[COMPLNTO]                   AS Complemento
                      ,[OEMISS]                     AS OrgaoExpedidor
                      ,[UFEMISS]                    AS UfEmissor
                      ,[DDDCEL]                     AS DddCelular
                      ,[DDDRES]                     AS DddResidencial
                      ,[DDDCOM]                     AS DddComercial
                      ,[RAMALCO]                    AS Ramal
                      ,[INSTORIG]                   AS Instituicao_Origem
                      ,[REGSERVI]                   AS RegistroServidor
                      ,[USERPASSWORD]               AS Senha
                      ,[EMAIL_SERVIDOR]             AS EmailServidor
                      ,[EMAIL_PROFESSOR]            AS EmailProfessor
                     FROM
                       [dbo].[LDAP_ID]      WITH(NOLOCK)
                     INNER JOIN
                       [dbo].[Arvore_LDAP]  WITH(NOLOCK)    ON  [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore ");
        #endregion

        #region| Select Methods
        public CommandDefinition GetCommandSelectByIdLdap(string idLdap)
        {
            _sqlSelect.Append(" WHERE [ID_LDAP] = @IDLDAP");

            var param = new
            {
                IDLDAP = idLdap
            };

            return new CommandDefinition(_sqlSelect.ToString(), parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandSelectByCpf(string cpf)
        {
            _sqlSelect.Append(" WHERE [CPF] = @CPF");

            var param = new
            {
                CPF = new DbString { Value = cpf, IsFixedLength = false, Length = 15, IsAnsi = true }
            };

            return new CommandDefinition(_sqlSelect.ToString(), parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandSelectByNameWithPassword(string name)
        {
            _sqlSelectWithPassword.Append(" WHERE [CN] = @NAME");

            var param = new
            {
                NAME = new DbString { Value = name, IsFixedLength = false, Length = 250, IsAnsi = true }
            };

            return new CommandDefinition(_sqlSelectWithPassword.ToString(), parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandSelectByCpfWithPassword(string cpf)
        {
            string sql =
                    @"SELECT 
                       [ID_LDAP]				AS IDLDAP
                      ,[CN]						AS Nome
                      ,[CPF]					AS CPF
                      ,[USERPASSWORD]           AS Senha
                     FROM 
                       [dbo].[LDAP_ID] WITH (NOLOCK)
					 INNER JOIN
					   [dbo].[Arvore_LDAP] WITH (NOLOCK)
					 ON 
					   [dbo].[LDAP_ID].IDarvore = [dbo].[Arvore_LDAP].id_arvore
                     WHERE 
	                    [CPF] = @CPF";

            var param = new
            {
                CPF = new DbString { Value = cpf, IsFixedLength = false, Length = 15, IsAnsi = true }
            };

            return new CommandDefinition(sql, parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandSelectFiltro(Usuario usuario)
        {
            _sqlSelect.Append(@" 
                    WHERE 
	                    ([CN] LIKE @NOME OR @NOME IS NULL)
                    AND
	                    ([ID_LDAP] = @IDLDAP OR @IDLDAP IS NULL)
                    AND
	                    ([RG] LIKE @RG OR @RG IS NULL)
                    AND
	                    ([CPF] LIKE @CPF OR @CPF IS NULL)
                    AND
	                    ([EMAIL] LIKE @EMAIL OR @EMAIL IS NULL)
                    AND
                        ([IDarvore] = @IDARVORE OR @IDARVORE IS NULL)");

            var param = new
            {
                NOME = new DbString { Value = string.IsNullOrEmpty(usuario.Nome) ? null : string.Concat("%", usuario.Nome, "%"), IsFixedLength = false, Length = 254, IsAnsi = true },
                Email = new DbString { Value = string.IsNullOrEmpty(usuario.Email) ? null : string.Concat("%", usuario.Email, "%"), IsFixedLength = false, Length = 254, IsAnsi = true },
                IDLDAP = new DbString { Value = string.IsNullOrEmpty(usuario.IDLDAP) ? null : usuario.IDLDAP, IsFixedLength = false, Length = 30, IsAnsi = true },
                RG = new DbString { Value = string.IsNullOrEmpty(usuario.RG) ? null : string.Concat("%", usuario.RG, "%"), IsFixedLength = false, Length = 30, IsAnsi = true },
                CPF = new DbString { Value = string.IsNullOrEmpty(usuario.CPF) ? null : string.Concat("%", usuario.CPF, "%"), IsFixedLength = false, Length = 30, IsAnsi = true },
                IDARVORE = new DbString { Value = usuario.IdArvore.HasValue ? usuario.IdArvore.ToString() : null, IsFixedLength = false, Length = 30, IsAnsi = true },

            };
            return new CommandDefinition(_sqlSelect.ToString(), parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandSelectFiltroWithPassword(Usuario usuario)
        {
            _sqlSelectWithPassword.Append(@" 
                    WHERE 
	                    ([CN] LIKE @NOME OR @NOME IS NULL)
                    AND
	                    ([ID_LDAP] = @IDLDAP OR @IDLDAP IS NULL)
                    AND
	                    ([RG] LIKE @RG OR @RG IS NULL)
                    AND
	                    ([CPF] LIKE @CPF OR @CPF IS NULL)
                    AND
	                    ([EMAIL] LIKE @EMAIL OR @EMAIL IS NULL)
                    AND
                        ([IDarvore] = @IDARVORE OR @IDARVORE IS NULL)");

            var param = new
            {
                NOME = new DbString { Value = string.IsNullOrEmpty(usuario.Nome) ? null : string.Concat("%", usuario.Nome, "%"), IsFixedLength = false, Length = 254, IsAnsi = true },
                Email = new DbString { Value = string.IsNullOrEmpty(usuario.Email) ? null : string.Concat("%", usuario.Email, "%"), IsFixedLength = false, Length = 254, IsAnsi = true },
                IDLDAP = new DbString { Value = string.IsNullOrEmpty(usuario.IDLDAP) ? null : usuario.IDLDAP, IsFixedLength = false, Length = 30, IsAnsi = true },
                RG = new DbString { Value = string.IsNullOrEmpty(usuario.RG) ? null : string.Concat("%", usuario.RG, "%"), IsFixedLength = false, Length = 30, IsAnsi = true },
                CPF = new DbString { Value = string.IsNullOrEmpty(usuario.CPF) ? null : string.Concat("%", usuario.CPF, "%"), IsFixedLength = false, Length = 30, IsAnsi = true },
                IDARVORE = new DbString { Value = usuario.IdArvore.HasValue ? usuario.IdArvore.ToString() : null, IsFixedLength = false, Length = 30, IsAnsi = true },

            };
            return new CommandDefinition(_sqlSelectWithPassword.ToString(), parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandSelectFiltro(Usuario usuario, Op operador)
        {
            string operadorAndOr = string.Empty;

            if (operador == Op.AND)
                operadorAndOr = "AND";
            else
                operadorAndOr = "OR";

            _sqlSelect.Append(@"
                      WHERE 
	                    ([CN] LIKE @NOME OR @NOME IS NULL)
                      @OP
	                    ([ID_LDAP] = @IDLDAP OR @IDLDAP IS NULL)
                      @OP
	                    ([RG] LIKE @RG OR @RG IS NULL)
                      @OP
	                    ([CPF] LIKE @CPF OR @CPF IS NULL)
                      @OP
                        ([IDarvore] = @IDARVORE OR @IDARVORE IS NULL)");

            var param = new
            {
                NOME = new DbString { Value = string.IsNullOrEmpty(usuario.Nome) ? null : string.Concat("%", usuario.Nome, "%"), IsFixedLength = false, Length = 254, IsAnsi = true },
                Email = new DbString { Value = string.IsNullOrEmpty(usuario.Email) ? null : string.Concat("%", usuario.Email, "%"), IsFixedLength = false, Length = 254, IsAnsi = true },
                IDLDAP = new DbString { Value = string.IsNullOrEmpty(usuario.IDLDAP) ? null : usuario.IDLDAP, IsFixedLength = false, Length = 30, IsAnsi = true },
                RG = new DbString { Value = string.IsNullOrEmpty(usuario.RG) ? null : string.Concat("%", usuario.RG, "%"), IsFixedLength = false, Length = 30, IsAnsi = true },
                CPF = new DbString { Value = string.IsNullOrEmpty(usuario.CPF) ? null : string.Concat("%", usuario.CPF, "%"), IsFixedLength = false, Length = 30, IsAnsi = true },
                IDARVORE = new DbString { Value = usuario.IdArvore.HasValue ? usuario.IdArvore.ToString() : null, IsFixedLength = false, Length = 30, IsAnsi = true },

            };

            _sqlSelect = _sqlSelect.Replace("@OP", operadorAndOr);

            return new CommandDefinition(_sqlSelect.ToString(), parameters: param, transaction: null, commandType: CommandType.Text);
        }
        #endregion

        #region| Crud Methods
        public CommandDefinition GetCommandInsert(Usuario usuario)
        {
            string sql = @"
             INSERT INTO [dbo].[LDAP_ID]
                   ([IDarvore]
                   ,[dt_imput]
                   ,[EMAIL]
                   ,[CN]
                   ,[CPF]
                   ,[RG]
                   ,[SEXO]
                   ,[DT_NASCIMENTO]
                   ,[TELEPHONENUMBER]
                   ,[CELLULARTELEPHONENUMBER]
                   ,[HOMEPHONE]
                   ,[STREET]
                   ,[POSTALADDRESS]
                   ,[POSTALCODE]
                   ,[CIDADE]
                   ,[ESTADO]
                   ,[NUM_BANCO]
                   ,[NUM_AGENCIA]
                   ,[TIPO_CONTA]
                   ,[NUM_CONTA]
                   ,[DIG_CONTA]
                   ,[FLAG_VINCULADO_FDE]
                   ,[EMPLOYEETYPE]
                   ,[GIVENNAME]
                   ,[SN]
                   ,[BUSINESSCATEGORY]
                   ,[RS]
                   ,[NUMEND]
                   ,[COMPLNTO]
                   ,[OEMISS]
                   ,[UFEMISS]
                   ,[DDDCEL]
                   ,[DDDRES]
                   ,[DDDCOM]
                   ,[RAMALCO]
                   ,[INSTORIG]
                   ,[REGSERVI]
                   ,[USERPASSWORD])
             VALUES
                   (@IDArvore
                   ,@dt_imput
                   ,@EMAIL
                   ,@CN
                   ,@CPF
                   ,@RG
                   ,@SEXO
                   ,@DT_NASCIMENTO
                   ,@TELEPHONENUMBER
                   ,@CELLULARTELEPHONENUMBER
                   ,@HOMEPHONE
                   ,@STREET
                   ,@POSTALADDRESS
                   ,@POSTALCODE
                   ,@CIDADE
                   ,@ESTADO
                   ,@NUM_BANCO
                   ,@NUM_AGENCIA
                   ,@TIPO_CONTA
                   ,@NUM_CONTA
                   ,@DIG_CONTA
                   ,@FLAG_VINCULADO_FDE
                   ,@EMPLOYEETYPE
                   ,@GIVENNAME
                   ,@SN
                   ,@BUSINESSCATEGORY
                   ,@RS
                   ,@NUMEND
                   ,@COMPLNTO
                   ,@OEMISS
                   ,@UFEMISS
                   ,@DDDCEL
                   ,@DDDRES
                   ,@DDDCOM
                   ,@RAMALCO
                   ,@INSTORIG
                   ,@REGSERVI
                   ,@USERPASSWORD)

                    SELECT  SCOPE_IDENTITY()";

            object param = new
            {
                IDArvore = usuario.IdArvore.HasValue ? usuario.IdArvore.Value : 0,
                dt_imput = DateTime.Now,
                Email = new DbString { Value = usuario.Email, IsFixedLength = false, Length = 250, IsAnsi = true },
                CN = new DbString { Value = usuario.Nome, IsFixedLength = false, Length = 250, IsAnsi = true },
                CPF = new DbString { Value = usuario.CPF, IsFixedLength = false, Length = 15, IsAnsi = true },
                RG = new DbString { Value = usuario.RG, IsFixedLength = false, Length = 25, IsAnsi = true },
                SEXO = new DbString { Value = usuario.Sexo, IsFixedLength = true, Length = 5, IsAnsi = true },
                DT_NASCIMENTO = usuario.DataNascimento,
                TELEPHONENUMBER = new DbString { Value = usuario.TelefoneComercial, IsFixedLength = false, Length = 40, IsAnsi = true },
                CELLULARTELEPHONENUMBER = new DbString { Value = usuario.TelefoneCelular, IsFixedLength = false, Length = 40, IsAnsi = true },
                HOMEPHONE = new DbString { Value = usuario.TelefoneResidencial, IsFixedLength = false, Length = 40, IsAnsi = true },
                STREET = new DbString { Value = usuario.Logradouro, IsFixedLength = false, Length = 40, IsAnsi = true },
                POSTALADDRESS = new DbString { Value = usuario.Bairro, IsFixedLength = false, Length = 200, IsAnsi = true },
                POSTALCODE = new DbString { Value = usuario.CEP, IsFixedLength = false, Length = 20, IsAnsi = true },
                CIDADE = new DbString { Value = usuario.Cidade, IsFixedLength = false, Length = 260, IsAnsi = true },
                ESTADO = new DbString { Value = usuario.UF, IsFixedLength = false, Length = 260, IsAnsi = true },
                NUM_BANCO = new DbString { Value = usuario.NumeroBanco, IsFixedLength = false, Length = 10, IsAnsi = true },
                NUM_AGENCIA = new DbString { Value = usuario.Agencia, IsFixedLength = false, Length = 10, IsAnsi = true },
                TIPO_CONTA = new DbString { Value = usuario.TipoConta, IsFixedLength = false, Length = 15, IsAnsi = true },
                NUM_CONTA = new DbString { Value = usuario.NumeroConta, IsFixedLength = false, Length = 10, IsAnsi = true },
                DIG_CONTA = new DbString { Value = usuario.Digito, IsFixedLength = false, Length = 5, IsAnsi = true },
                FLAG_VINCULADO_FDE = new DbString { Value = usuario.VinculadoFDE, IsFixedLength = false, Length = 10, IsAnsi = true },
                EMPLOYEETYPE = new DbString { Value = usuario.Cargo, IsFixedLength = false, Length = 60, IsAnsi = true },
                GIVENNAME = new DbString { Value = usuario.PrimeironoNome, IsFixedLength = false, Length = 80, IsAnsi = true },
                SN = new DbString { Value = usuario.Sobrenome, IsFixedLength = false, Length = 100, IsAnsi = true },
                BUSINESSCATEGORY = new DbString { Value = usuario.Departamento, IsFixedLength = false, Length = 60, IsAnsi = true },
                RS = string.Empty,
                NUMEND = new DbString { Value = usuario.Numero, IsFixedLength = false, Length = 50, IsAnsi = true },
                COMPLNTO = new DbString { Value = usuario.Complemento, IsFixedLength = false, Length = 100, IsAnsi = true },
                OEMISS = new DbString { Value = usuario.OrgaoExpedidor, IsFixedLength = false, Length = 20, IsAnsi = true },
                UFEMISS = new DbString { Value = usuario.UfEmissor, IsFixedLength = false, Length = 20, IsAnsi = true },
                DDDCEL = new DbString { Value = usuario.DddCelular, IsFixedLength = false, Length = 10, IsAnsi = true },
                DDDRES = new DbString { Value = usuario.DddResidencial, IsFixedLength = false, Length = 10, IsAnsi = true },
                DDDCOM = new DbString { Value = usuario.DddComercial, IsFixedLength = false, Length = 10, IsAnsi = true },
                RAMALCO = new DbString { Value = usuario.Ramal, IsFixedLength = false, Length = 10, IsAnsi = true },
                INSTORIG = new DbString { Value = usuario.Instituicao_Origem, IsFixedLength = false, Length = 20, IsAnsi = true },
                REGSERVI = new DbString { Value = usuario.RegistroServidor, IsFixedLength = false, Length = 20, IsAnsi = true },
                USERPASSWORD = new DbString { Value = new LDAPCripto().Criptografar(usuario.RG), IsFixedLength = false, Length = 120, IsAnsi = true },
            };

            return new CommandDefinition(sql, parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandUpdate(Usuario usuario)
        {
            string _sql = @"UPDATE [dbo].[LDAP_ID]
                       SET [IDarvore] = @IDarvore
                          ,[dt_imput] = @dt_imput
                          ,[EMAIL] = @EMAIL
                          ,[CN] = @CN
                          ,[CPF] = @CPF
                          ,[RG] = @RG
                          ,[SEXO] = @SEXO
                          ,[DT_NASCIMENTO] = @DT_NASCIMENTO
                          ,[TELEPHONENUMBER] = @TELEPHONENUMBER
                          ,[CELLULARTELEPHONENUMBER] = @CELLULARTELEPHONENUMBER
                          ,[HOMEPHONE] = @HOMEPHONE
                          ,[STREET] = @STREET
                          ,[POSTALADDRESS] = @POSTALADDRESS
                          ,[POSTALCODE] = @POSTALCODE
                          ,[CIDADE] = @CIDADE
                          ,[ESTADO] = @ESTADO
                          ,[NUM_BANCO] = @NUM_BANCO
                          ,[NUM_AGENCIA] = @NUM_AGENCIA
                          ,[TIPO_CONTA] = @TIPO_CONTA
                          ,[NUM_CONTA] = @NUM_CONTA
                          ,[DIG_CONTA] = @DIG_CONTA
                          ,[FLAG_VINCULADO_FDE] = @FLAG_VINCULADO_FDE
                          ,[EMPLOYEETYPE] = @EMPLOYEETYPE
                          ,[GIVENNAME] = @GIVENNAME
                          ,[SN] = @SN
                          ,[BUSINESSCATEGORY] = @BUSINESSCATEGORY
                          ,[RS] = @RS
                          ,[NUMEND] = @NUMEND
                          ,[COMPLNTO] = @COMPLNTO
                          ,[OEMISS] = @OEMISS
                          ,[UFEMISS] = @UFEMISS
                          ,[DDDCEL] = @DDDCEL
                          ,[DDDRES] = @DDDRES
                          ,[DDDCOM] = @DDDCOM
                          ,[RAMALCO] = @RAMALCO
                          ,[INSTORIG] = @INSTORIG
                          ,[REGSERVI] = @REGSERVI
                          --,[USERPASSWORD] = @USERPASSWORD
                    WHERE 
                           [ID_LDAP] = @IDLDAP";

            object param = new
            {
                IDLDAP = usuario.IDLDAP,
                IDArvore = usuario.IdArvore.HasValue ? usuario.IdArvore.Value : 0,
                dt_imput = DateTime.Now,
                Email = new DbString { Value = usuario.Email, IsFixedLength = false, Length = 250, IsAnsi = true },
                CN = new DbString { Value = usuario.Nome, IsFixedLength = false, Length = 250, IsAnsi = true },
                CPF = new DbString { Value = usuario.CPF, IsFixedLength = false, Length = 15, IsAnsi = true },
                RG = new DbString { Value = usuario.RG, IsFixedLength = false, Length = 25, IsAnsi = true },
                SEXO = new DbString { Value = usuario.Sexo, IsFixedLength = true, Length = 5, IsAnsi = true },
                DT_NASCIMENTO = usuario.DataNascimento,
                TELEPHONENUMBER = new DbString { Value = usuario.TelefoneComercial, IsFixedLength = false, Length = 40, IsAnsi = true },
                CELLULARTELEPHONENUMBER = new DbString { Value = usuario.TelefoneCelular, IsFixedLength = false, Length = 40, IsAnsi = true },
                HOMEPHONE = new DbString { Value = usuario.TelefoneResidencial, IsFixedLength = false, Length = 40, IsAnsi = true },
                STREET = new DbString { Value = usuario.Logradouro, IsFixedLength = false, Length = 40, IsAnsi = true },
                POSTALADDRESS = new DbString { Value = usuario.Bairro, IsFixedLength = false, Length = 200, IsAnsi = true },
                POSTALCODE = new DbString { Value = usuario.CEP, IsFixedLength = false, Length = 20, IsAnsi = true },
                CIDADE = new DbString { Value = usuario.Cidade, IsFixedLength = false, Length = 260, IsAnsi = true },
                ESTADO = new DbString { Value = usuario.UF, IsFixedLength = false, Length = 260, IsAnsi = true },
                NUM_BANCO = new DbString { Value = usuario.NumeroBanco, IsFixedLength = false, Length = 10, IsAnsi = true },
                NUM_AGENCIA = new DbString { Value = usuario.Agencia, IsFixedLength = false, Length = 10, IsAnsi = true },
                TIPO_CONTA = new DbString { Value = usuario.TipoConta, IsFixedLength = false, Length = 15, IsAnsi = true },
                NUM_CONTA = new DbString { Value = usuario.NumeroConta, IsFixedLength = false, Length = 10, IsAnsi = true },
                DIG_CONTA = new DbString { Value = usuario.Digito, IsFixedLength = false, Length = 5, IsAnsi = true },
                FLAG_VINCULADO_FDE = new DbString { Value = usuario.VinculadoFDE, IsFixedLength = false, Length = 10, IsAnsi = true },
                EMPLOYEETYPE = new DbString { Value = usuario.Cargo, IsFixedLength = false, Length = 60, IsAnsi = true },
                GIVENNAME = new DbString { Value = usuario.PrimeironoNome, IsFixedLength = false, Length = 80, IsAnsi = true },
                SN = new DbString { Value = usuario.Sobrenome, IsFixedLength = false, Length = 100, IsAnsi = true },
                BUSINESSCATEGORY = new DbString { Value = usuario.Departamento, IsFixedLength = false, Length = 60, IsAnsi = true },
                RS = string.Empty,
                NUMEND = new DbString { Value = usuario.Numero, IsFixedLength = false, Length = 50, IsAnsi = true },
                COMPLNTO = new DbString { Value = usuario.Complemento, IsFixedLength = false, Length = 100, IsAnsi = true },
                OEMISS = new DbString { Value = usuario.OrgaoExpedidor, IsFixedLength = false, Length = 20, IsAnsi = true },
                UFEMISS = new DbString { Value = usuario.UfEmissor, IsFixedLength = false, Length = 20, IsAnsi = true },
                DDDCEL = new DbString { Value = usuario.DddCelular, IsFixedLength = false, Length = 10, IsAnsi = true },
                DDDRES = new DbString { Value = usuario.DddResidencial, IsFixedLength = false, Length = 10, IsAnsi = true },
                DDDCOM = new DbString { Value = usuario.DddComercial, IsFixedLength = false, Length = 10, IsAnsi = true },
                RAMALCO = new DbString { Value = usuario.Ramal, IsFixedLength = false, Length = 10, IsAnsi = true },
                INSTORIG = new DbString { Value = usuario.Instituicao_Origem, IsFixedLength = false, Length = 20, IsAnsi = true },
                REGSERVI = new DbString { Value = usuario.RegistroServidor, IsFixedLength = false, Length = 20, IsAnsi = true },
            };

            return new CommandDefinition(_sql, parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandDelete(string idLdap)
        {
            string _sql = @"
                       DELETE 
                        FROM [dbo].[LDAP_ID]
                       WHERE [ID_LDAP] = @IDLDAP";

            object param = new
            {
                IDLDAP = idLdap
            };

            return new CommandDefinition(_sql, parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandAtualizarSenha(string idLdap, string senha)
        {
            string _sql = @"
                    UPDATE [dbo].[LDAP_ID]
                       SET [USERPASSWORD] = @USERPASSWORD
                    WHERE 
                           [ID_LDAP] = @IDLDAP";

            object param = new
            {
                IDLDAP = idLdap,
                USERPASSWORD = new DbString { Value = senha, IsFixedLength = false, Length = 120, IsAnsi = true },
            };


            return new CommandDefinition(_sql, parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandResetarSenha(string idLdap, string cpf)
        {
            string _sql = @"
                    UPDATE [dbo].[LDAP_ID]
                       SET [USERPASSWORD] = USERPASSWORD
                    WHERE 
                           [ID_LDAP] = @IDLDAP";

            object param = new
            {
                IDLDAP = idLdap,
                USERPASSWORD = new DbString { Value = new LDAPCripto().Criptografar(cpf), IsFixedLength = false, Length = 120, IsAnsi = true },
            };


            return new CommandDefinition(_sql, parameters: param, transaction: null, commandType: CommandType.Text);
        }

        public CommandDefinition GetCommandValidaRgCpf(string rg, string cpf, string idLdap, string email)
        {
            string _sql = @"
                     DECLARE 
                     @IDLDAPRGEXISTENTE	    VARCHAR(20) = NULL,
		             @IDLDAPCPFEXISTENTE    VARCHAR(20) = NULL,
		             @IDLDAPEMAILEXISTENTE  VARCHAR(20) = NULL,
                     @ERRO		            VARCHAR(250) = NULL;
                     
                    SELECT 
                        @IDLDAPRGEXISTENTE = L.ID_LDAP 
                     FROM 
                        LDAP_ID L  WITH (NOLOCK)
                     WHERE 
                        L.RG = @RG 
                     AND 
                        (L.ID_LDAP <> @IDLDAP OR @IDLDAP IS NULL);

                    SELECT 
                        @IDLDAPEMAILEXISTENTE = L.ID_LDAP 
                     FROM 
                        LDAP_ID L WITH (NOLOCK)
                     WHERE 
                        L.EMAIL = @EMAIL 
                     AND 
                        (L.ID_LDAP <> @IDLDAP OR @IDLDAP IS NULL);
                    
		            SELECT 
                        @IDLDAPCPFEXISTENTE = L.ID_LDAP 
                    FROM 
                        LDAP_ID L WITH (NOLOCK)
                    WHERE 
                        L.CPF = @CPF 
                    AND 
                        (L.ID_LDAP <> @IDLDAP OR @IDLDAP IS NULL);

					PRINT @IDLDAPRGEXISTENTE
					PRINT @IDLDAPCPFEXISTENTE
					PRINT @IDLDAPEMAILEXISTENTE
		
					-- APENAS O RG COM ERRO
					IF(@IDLDAPRGEXISTENTE IS NOT NULL AND @IDLDAPCPFEXISTENTE IS NULL AND @IDLDAPEMAILEXISTENTE IS NULL)
					BEGIN
						SET @ERRO = 'O RG informado já existe no sistema';
					END
		
					-- APENAS O E-MAIL COM ERRO
					IF(@IDLDAPRGEXISTENTE IS NULL AND @IDLDAPCPFEXISTENTE IS NULL AND @IDLDAPEMAILEXISTENTE IS NOT NULL)
					BEGIN
						SET @ERRO = 'O E-mail informado já existe no sistema';
					END
		            
					-- APENAS O CPF COM ERRO
					IF(@IDLDAPRGEXISTENTE IS NULL AND @IDLDAPCPFEXISTENTE IS NOT NULL AND @IDLDAPEMAILEXISTENTE IS NULL)
					BEGIN
						SET @ERRO = 'O CPF informado já existe no sistema';
					END
					
					-- RG E CPF COM ERRO
					IF(@IDLDAPRGEXISTENTE IS NOT NULL AND @IDLDAPCPFEXISTENTE IS NOT NULL AND @IDLDAPEMAILEXISTENTE IS NULL)
					BEGIN
						SET @ERRO = 'O RG e o CPF informados já existem no sistema';
					END
		
					-- RG E E-MAIL COM ERRO
					IF(@IDLDAPRGEXISTENTE IS NOT NULL AND @IDLDAPCPFEXISTENTE IS NULL AND @IDLDAPEMAILEXISTENTE IS NOT NULL)
					BEGIN
						SET @ERRO = 'O RG e o E-mail informados já existem no sistema';
					END
		
					-- CPF E E-MAIL COM ERRO
					IF(@IDLDAPRGEXISTENTE IS NULL AND @IDLDAPCPFEXISTENTE IS NOT NULL AND @IDLDAPEMAILEXISTENTE IS NOT NULL)
					BEGIN
						SET @ERRO = 'O CPF e o E-mail informados já existem no sistema';
					END
		                
					IF(@IDLDAPRGEXISTENTE IS NOT NULL AND @IDLDAPCPFEXISTENTE IS NOT NULL AND @IDLDAPEMAILEXISTENTE IS NOT NULL)
					BEGIN
						SET @ERRO = 'O CPF, RG e o E-mail informados já existem no sistema';
					END
                    
                    IF(@IDLDAPRGEXISTENTE IS NOT NULL OR @IDLDAPCPFEXISTENTE IS NOT NULL OR @IDLDAPEMAILEXISTENTE IS NOT NULL)
	                BEGIN
                        RAISERROR(@ERRO, 16, 1)
	                END";
            var param = new
            {
                RG = new DbString { Value = rg, IsFixedLength = false, Length = 30, IsAnsi = true },
                IDLDAP = new DbString { Value = idLdap, IsFixedLength = false, Length = 30, IsAnsi = true },
                CPF = new DbString { Value = cpf, IsFixedLength = false, Length = 30, IsAnsi = true },
                Email = new DbString { Value = email, IsFixedLength = false, Length = 254, IsAnsi = true },

            };
            return new CommandDefinition(_sql, parameters: param, transaction: null, commandType: CommandType.Text);

        }
        #endregion
    }
}
