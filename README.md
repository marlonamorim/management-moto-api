```Solução com conjunto de apis para gerenciamento de locação de motocicletas```
   1. Cadastro e alteração de usuários e perfil;
   2. Gerenciamento de token de acesso;
   3. Listagem de planos disponíveis;
   4. Geração de cotação e cadastro de locação.

```Modelo de dados```
![diagrama-dados-motocycle](https://github.com/marlonamorim/management-moto-api/assets/36924662/8b1b684f-7cc3-4faf-a001-2c142f7978a3)

```Configurações de acesso```

No arquivo appsettings está disponível a connectionstring de acesso ao db do mongo, pois como é para utilização de poc, não existe quaisquer problemas no compartilhamento.
O acesso ao db também está público a partir de qualquer origem.


É necessário realizar autenticação no serviço api/access-manager, afim de ser gerado o bearer token, após  ageração, utilizá-lo no header do swagger.

![image](https://github.com/marlonamorim/management-moto-api/assets/36924662/0e760495-ccfc-45cb-9312-318961ae7310)



É importante lembrar que para a locação de uma moto,se faz necessário estar autenticado com o perfil de entregador.

![image](https://github.com/marlonamorim/management-moto-api/assets/36924662/237f725b-30e1-42b5-a255-26df469ba709)


```Executando api com Docker```

   1. Execute o seguinte comando na raiz onde se encontra o arquivo Docker
      ```docker build -t management-moto-api-image .```
      Esse comando irá fazer o download do sdk do .net 8 e gerar a imagem através das instruções contidas no arquivo.

   2. Em seguida, execute o seguinte comando a fim de criar o container através da imagem gerada
      ```docker run -d -p 5296:8080 --name="management-moto-api-core" management-moto-api-image```

   Por fim, acesse no browser a api a partir da porta indicada.
![image](https://github.com/marlonamorim/management-moto-api/assets/36924662/1ca74309-649b-4a38-b043-076f78e042a6)
