# Meus Apoios RJ

Primeira versão nativa em .NET MAUI inspirada na organização do site do arquivo peterapoia-main.zip.

A tela mostra presidente, senador (vaga 1) e senador (vaga 2), com Rio de Janeiro fixo. Um interruptor permite exibir deputado federal e estadual. O botão copia um resumo em texto quando houver pelo menos um nome definido. Funciona sem conexão: não usa serviços externos.

## Definir os apoios

Edite `ProjetoMAUI/Resources/Raw/candidates.json` e preencha `Name` (nome), `Party` (partido) e `Number` (número, sempre entre aspas). Os campos vazios aparecem como “A definir”. Compile novamente após editar o arquivo. Esta versão não possui cadastro dentro do aplicativo.

Por solicitação do usuário, os nomes, partidos e números de presidente e dos candidatos do RJ foram importados do ZIP. Esses dados representam o conteúdo do arquivo, sem verificação atual em fonte oficial. Ao exibir deputados, o resumo inclui todas as indicações, não uma seleção individual. O ZIP contém um único HTML com CSS, JavaScript, dados dos estados e referências externas a fotos, além de imagens de identidade visual. Ele também contém mapa interativo, entrevistas e uma colinha. Esta adaptação tem interface própria e não copia imagens, marca ou código do site.

## Executar

Abra a solução no Visual Studio com a carga de trabalho .NET MAUI, selecione Windows ou um dispositivo Android e execute. O projeto também mantém os destinos iOS e Mac Catalyst do modelo original, que exigem o ambiente correspondente.

Verificação Windows: `dotnet build ProjetoMAUI/ProjetoMAUI.csproj -f net10.0-windows10.0.19041.0`.

