# AppEvandroEuApoio

Primeira versão nativa em .NET MAUI inspirada na organização do site do arquivo peterapoia-main.zip.

A tela mostra presidente, governador, senador (vaga 1) e senador (vaga 2), com Rio de Janeiro fixo. Um interruptor permite exibir deputado federal e estadual. O botão copia um resumo em texto quando houver pelo menos um nome definido. Funciona sem conexão: não usa serviços externos.

## Definir os apoios

Edite `ProjetoMAUI/Resources/Raw/candidates.json` e preencha `Name` (nome), `Party` (partido) e `Number` (número, sempre entre aspas). Os campos vazios aparecem como “A definir”. Compile novamente após editar o arquivo. Esta versão não possui cadastro dentro do aplicativo.

Por solicitação do usuário, os nomes, partidos e números de presidente e dos candidatos do RJ foram importados do ZIP. Esses dados representam o conteúdo do arquivo, sem verificação atual em fonte oficial. Ao exibir deputados, o resumo inclui todas as indicações, não uma seleção individual. O ZIP contém um único HTML com CSS, JavaScript, dados dos estados e referências externas a fotos, além de imagens de identidade visual. Ele também contém mapa interativo, entrevistas e uma colinha. Esta adaptação tem interface própria e não copia imagens, marca ou código do site.

## Executar

Abra a solução no Visual Studio com a carga de trabalho .NET MAUI, selecione seu celular Android ou emulador e execute. O projeto compila exclusivamente para Android. As pastas de outras plataformas foram preservadas como referência para uma futura versão iOS; elas não são compiladas nem incluídas no aplicativo Android.

Verificação Android: `dotnet build ProjetoMAUI/ProjetoMAUI.csproj`.

Arquiteturas mantidas: `android-arm` (seu Xiaomi de 32 bits), `android-arm64` (outros celulares) e `android-x64` (emulador). A imagem de exemplo `dotnet_bot.png` e o texto `AboutAssets.txt` não entram no pacote. Remover destinos de outras plataformas simplifica a compilação, mas não remove bibliotecas do APK Android, que já era específico dessa plataforma. Para distribuição, use Release, que aplica a redução de código não utilizado padrão do MAUI.



## Identidade do aplicativo

Nome exibido: AppEvandroEuApoio. Identificador Android: br.com.evandroedgariano.appevandroeuapoio, baseado no domínio evandroedgariano.com.br. Esse identificador deve ser mantido nas atualizações após a publicação. Os candidatos foram conferidos e editados pelo usuário, incluindo governador.

