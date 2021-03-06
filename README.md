# CookAlong

An AR application to help streamline the cooking process. Users can walk through a recipe step by step, see pictures of ingredients, manage multiple timers, and watch instructional videos, all within the app.

![Logo](https://github.com/dartmouth-cs98/19f-cookalong/blob/master/cookalong-horiz.png)
![Video](https://github.com/dartmouth-cs98/19f-cookalong/blob/master/video.gif)
![Timers](https://github.com/dartmouth-cs98/19f-cookalong/blob/master/multiTimers.gif)


## Architecture
Backend : https://github.com/dartmouth-cs98/cookalong-backend
* Springboot Java for rest API calls
* Data storage in MongoDB Heroku app

Frontend: https://github.com/dartmouth-cs98/cook_along
* Unity app coded in C#
* Building onto a MagicLeap headset

Backend interface : https://github.com/dartmouth-cs98/cookalong-interface
* React.js frontend for interacting with backend
* Deployed with Surge.sh

## Setup

1. Have Unity Installed
2. Have The Lab Installed
3. Configure the connection between the two using links below:

[Dev Set up](https://creator.magicleap.com/learn/guides/develop-setup)

[Device Set up](https://creator.magicleap.com/learn/guides/develop-device-setup)

[Connect](https://creator.magicleap.com/learn/guides/connect-device)

[Certificate](https://creator.magicleap.com/learn/guides/developer-certificates)

[Starter](https://creator.magicleap.com/learn/guides/get-started-developing-in-unity)

[Unity Setup](https://creator.magicleap.com/learn/guides/unity-setup)

4. To modify App 
a. Clone from [repository](https://github.com/dartmouth-cs98/cook_along)
b. Change Certificate path with *Edit > Project Settings > Player > Lumin Tab > Publish Settings*
change ML certificate to the private key from the Certificate part of Step 3 above
c. Modify and push as needed
 


 
## Deployment

1. Download the .mpk file from the [repository](https://github.com/dartmouth-cs98/cook_along)
2. Download [The Lab](https://developer.magicleap.com/learn/guides/lab)
3. Start the Magic Leap Device Bridge using these [instructions](https://developer.magicleap.com/learn/guides/lab-device-bridge)
4. Click on `Apps`
5. Click on `Install App`
6. Select the downloaded .mpk file from step 1
7. Click launch



## Authors
Brian Tomasco <br/>
Zack Johnson <br/>
Anders Limstrom <br/>
Erika Ogino <br/>
Danielle Fang <br/>

## Acknowledgments
[MagicLeap Guides](https://creator.magicleap.com/learn/guides/)
