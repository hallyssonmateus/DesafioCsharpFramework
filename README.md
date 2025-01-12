# Simulator Télos - Nível #8  

Um simulador de gerenciamento de peças de veículos utilizando **.NET Framework 4.8** e **NHibernate** para consolidar conhecimentos em Object-Relational Mapping (ORM).

---

## 🛠️ Funcionalidades  

- **Cadastro de Peças**  
  Inclua novas peças com detalhes como nome, fabricante, tipo de veículo, categoria, preço de compra e venda.  

- **Consulta de Peças**  
  Busque peças por **ID** ou **nome**, com exibição completa das informações.  

- **Edição de Peças**  
  Atualize informações de peças cadastradas (exceto o ID).  

- **Exclusão de Peças (Softdelete)**  
  Remova peças do sistema utilizando um campo de status para exclusão lógica.  

- **Venda de Peças**  
  Simule vendas, alterando o status de disponibilidade e registre o **ID da peça** e o **valor de venda** (com suporte a descontos).  

- **Interface Gráfica Intuitiva**  
  Sistema fácil de usar desenvolvido com **Windows Forms**.  

---

## 💻 Tecnologias Utilizadas  

- **.NET Framework 4.8**  
- **C#**  
- **NHibernate (ORM)**  
- **LINQ e HQL**  
- **Windows Forms**  
- **MySQL ou SQL Server**  
- **Git e GitHub**  

---

## 🔗 Estrutura do Projeto  

- **UI (Apresentação):** Interface gráfica desenvolvida com Windows Forms.  
- **Controller (Negócios):** Lógica de negócios, validações e regras do sistema.  
- **Data (Dados):** Persistência com MySQL/SQL Server e NHibernate.  

---

## 📋 Roteiro  

### **1. Planejamento**  
- Detalhar requisitos e fluxos de trabalho.  
- Criar diagrama de classes e estrutura do banco de dados.  

### **2. Desenvolvimento**  
- Desenvolver a interface gráfica.  
- Implementar as funcionalidades principais (cadastro, consulta, edição, exclusão e venda).  
- Configurar persistência de dados com NHibernate.  

### **3. Entrega**  
- Código-fonte organizado e comentado.  
- Exportação do banco de dados (`dbmysql.sql` ou `dbsqlserver.sql`).  

---

## ✅ Critérios de Avaliação  

1. **Funcionalidade:** Atender a todos os requisitos.  
2. **Qualidade do Código:** Estrutura bem organizada e comentada.  
3. **Usabilidade:** Interface clara e intuitiva.  
4. **Documentação:** Instruções claras sobre uso e código.  

## 📋 Implementações Realizadas  

1. **Cadastro de Peças:**  
   - Funcionalidade completa de inclusão de peças com validações de entrada de dados.  

2. **Consulta de Peças:**  
   - Pesquisa por ID ou nome com exibição das informações no `DataGridView`.  

3. **Atualizações na Estrutura do Banco:**  
   - Adicionado suporte ao campo `Status` para armazenar "Ativo" ou "Inativo".  

4. **Persistência com NHibernate:**  
   - Configuração do NHibernate com suporte a SQL Server.  
   - Mapeamento das entidades `Peça` e `Vendas`.  

5. **Interface Gráfica (Windows Forms):**  
   - Formulários para cadastro e consulta.  
   - Botões funcionais com mensagens de sucesso ou erro.  

6. **Validações:**  
   - Validação de campos obrigatórios e formatos numéricos (ex.: preço e quantidade).  

7. **Configuração da Cultura:**  
   - Suporte para `pt-BR` com entrada de valores decimais no formato brasileiro (`40,00`).  

