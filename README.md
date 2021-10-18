# ViewTube App Case Study

### Name of the Project - ViewTube

## Objective 
### 
To allow viewers to view videos in different categories and mark them as favourites for later viewing.
The ViewTube App uses Google's Youtube API to list popular videos, list videos based on selected category.
The App allows registered users to mark their preferred video as favourites and remove them from favourites
The App provides Search Video functionality that allows the viewers to search for videos.
The App allows the registered viewers to select a video and play it.

## Specification :
- Application is mobile responsive.
- Below listed are the key functional requirements that has been implemented. [ For working with Youtube API, supporting url is also provided ]


1. To fetch Popular Youtube Videos
- `https://www.googleapis.com/youtube/v3/videos?part=snippet&chart=mostPopular&regionCode=in&maxResults=10&key=[Your_Api_Key]`


2. To fetch Youtube Videos for the selected Category
- `https://www.googleapis.com/youtube/v3/videos?part=snippet&regionCode=in&maxResults=10&videoCategoryId=[SELECTED_VIDEO_CATEGORY_ID]&chart=mostPopular&key=[YOUR_API_KEY]`

##### The Category ID can be fetched using following API 
- `https://www.googleapis.com/youtube/v3/videoCategories?part=snippet&regionCode=in&key=[YOUR_API_KEY]`

3. To search for Youtbue Video based on search text
- `https://www.googleapis.com/youtube/v3/search?part=snippet&maxResults=10&q=[VIDEO_SEARCH_TEXT]&key=[YOUR_API_KEY]`
 
***P.S :- To generate the API_KEY for the above endpoints and replace
[YOUR_API_KEY] with it.***

```
**To register for an API key, follow these steps:**
1. Login to gmail account
2. Follow the url :: https://developers.google.com/youtube/registering_an_application(AIzaSyCxHA-AZ4vZy16bGw9Iu6w1w3HXbBbA_LA)
3. On the Page, Click on Link `Credentials Page` or follow the url :: https://console.developers.google.com/apis/credentials
4. Click on Credentials
5. Click on Create
6. Click on Create Credentials-->API Key 
7. Copy the Created Key and Save it for later use in the application 
```

## Specifications of Project

* Angular as front end
* ASP.NET Core (.NET Core SDK) as backend with SQL server
* Swagger Implementation for documenting REST API
* CI/CD has implemented
* Authentication done using JWT Authentication
* End to end test cases [e2e].
* Unit testing for front end
* Unit testing for back end.
* DataSource for Videos in this is The Youtube API
* Entire application deployed in Docker containers.

## Tools and Technologies used
- VCS        :  Gitlab
- BackEnd    :  ASP.NET Core Web API
- FrondEnd   :  Angular
- Data Store : SQL Server
- Testing    :  Karma, Jasmine, Nunit
- Containerization: Docker
- CI         : Gitlab 
