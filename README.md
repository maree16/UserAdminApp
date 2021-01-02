# UserAdminApp
This is a WPF application which purpose is to perform CRUD operations on ElasticSearch data.
To run this Application 

download 
maree16/EmployeeEventFlowWithElasticSearch
maree16/EventFlowWithElasticSearchOrganization 

Each solution has two Api 
1) EventFlowApi 
2) EventFlowApi.Read 

EventFlowApi : It is write api . Configured with EventFlow , EventStore and RabbitMq.

EventFlowApi.Read: It is read api, Configured with Eventflow and Elastic Search. It configured a RabbitMq subscriber at startup.which invoked Domain event subscribers when data is arrived. and insert the data in ElasticSearch.

Prerequisites :

download and install Aspnetcore 3.1 framework.

Set following environment variables

ASPNETCORE_ENVIRONMENT, ELASTICSEARCHURL, EVENTSTOREURL, RABBITMQCONNECTION

After running the Apis
1) Start the WPF Application
2) Select The records 
3) On next Window, you can perform CRUD operations
