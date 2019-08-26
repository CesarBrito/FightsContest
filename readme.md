# Orientações
## Clone
Clonar [repositório](https://github.com/CesarBrito/FightsContest) para maquina local.

## Instalação
Caso não tenha o Dot.Net 2.2 instalado, instalar a partir do seguinte [link](https://dotnet.microsoft.com/download/dotnet-core/2.2).

## Build
### Após o clone e a instalação caso necessário.
#### Executar o batch clean seguindo os seguintes passos:
1. Clicar com o botão direito na solution.
2. Batch Build...
3. Na janela que se abrirá clicar em Select All(Selecionar todos).
4. Então clicar em Clear(Limpar).
5. Repetir o processo até o passo 3.
6. Então clicar em Build(Construir).
## Testes
### Após o build completo, seguir para os testes.
1. Clicar no menu Test(Testes).
2. Clicar na aba Windows.
3. Clicar em Test Explorer(Gerenciador de Testes).
4. Na janela que se abrirá, executar os teste com Ctrl+R,A ou clicar na seta de play com a legenda: Run All(Executar todos).

Após essa execução é esperado que todos os testes fiquem com o icone verde de sucesso.

## Executando a aplicação
### Após a execução dos teste, executar a aplicação seguindo os seguintes passos.
#### Caso o projeto "FightsContest.Application" não estiver selecionado, seguir os seguintes passos:
1. Clicar com o botão direito no projeto "FightsContest.Application".
2. Clicar no item: Set as StartUp Project(Definir como Projeto de Inicialização).
#### Após a verificação, seguir os seguites passos:
1. Precionar a teclar F5 ou clicar em Start(Iniciar) no menu superior.
2. Após o navegador abrir com a aplicação, selecionar 20 lutadores de sua preferência.
	1. O torneio só seguirá caso seja selecionado 20 lutadores válidos.
3. Clicar no botão Iniciar.

**O sistema apresentará o vencedor, segundo e terceiro lugar.**

# Sobre o projeto
## Arquitetura
Tentei implementar uma aquitetura simples utilizando DDD e TDD, utilizando inversão de dependência e segregação de interface.
Dividimos nossa aplicação de 3 camadas principais: Application, Domain, Infrastucture.
### Application
Tem como finalidade fazer a intermediação entre o usuário e o sistema.
### Infrastucture
Tem como finalidade manter os repositório, serviços de Cross Cutting, e Anti Corruption.
### Domain	
Essa camada pode ser considerada o core da aplicação, aonde possui todas as classes, interfaces e serviços.
## Tests
A camada de teste tem como finalidade fazer os teste de dominio, e validar regras de negócios para que o fluxo da aplicação aconteça normalmente, caso exista uma modificação em alguma classe core.


