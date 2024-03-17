


NeoCortexAPI Containerization
==============================
Pre-requisite:
1. Visual Studio IDE
2. .NET8 Framework
3. Docker Desktop


Environment Setup:
1. Clone the project from https://github.com/uddin-shahab/neocortexapi/tree/development
2. Open Visual Studio and open solution NeoCortexApi.sln
3. Rebuild Solution from Build menu
4. Make sure Docker Desktop is running
5. Open Terminal and run command "docker ps" to check if it's running properly
![alt text](image.png)
6. In Terminal go-to folder location where Dockerfile is location e.g. D:\ShababUddin\neocortexapi\source>
7. Build Docker image by running command "docker build -t a203 ." -t is used to tag image and you can use any word to tag your image
8. Once image creation is completed run the command to check your created image "docker image ls"
![alt text](image-1.png)
9. Run container by using following command

##### For SpatialPatternLearning

![alt text](image-5.png)
    D:\ShababUddin\neocortexapi\source>docker run a203 SPL fileName2058.txt 

##### For MultiSimpleSequenceLearning
![alt text](image-3.png)
    D:\ShababUddin\neocortexapi\source>docker run a203 MSSL fileName2058.txt  [{\"key\":\"S1\",\"values\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0]},{\"key\":\"S2\",\"values\":[10.0,11.0,12.0,13.0,14.0,15.0,16.0]}]

##### For MultiSequenceLearning
![alt text](image-4.png)
    D:\ShababUddin\neocortexapi\source>docker run a203 MSL fileName2058.txt  [{\"key\":\"S1\",\"values\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0]},{\"key\":\"S2\",\"values\":[10.0,11.0,12.0,13.0,14.0,15.0,16.0]}]

The above command will generate a Text file in Docker container with all the SDR values produced by NeocortexApi. See screenshot below:

![alt text](image-6.png)

Right click on file and click "Save" to save this file to your computer.

Now open the same file in any text editor e.g. Notepad++, copy the SDR values and save SDR values to another empty file and save it with name sampleinput.txt. This file will be used in later stage.










========================================

Location: neocortexapi\source
open terminal and go to Location of "Dockfile"

e.g; D:\ShababUddin\neocortexapi\source>

Commands:
docker build -t v1 .

docker run v1






python draw_figure.py -fn sampleOne.txt -gn test1 -mc 19 -ht 8 -yt yaxis -xt xaxis -min 50 -max 4000 -st 'single column' -fign CortialColumn -a


docker run sampleinp -fn "sampleinput.txt" -gn "sampleinput" -mc "19" -ht "8" -yt "yaxis" -xt "xaxis" -min "50" -max "4000" -st "'single column'" -fign "CortialColumn" -a



docker run -v D:\ShababUddin\neocortexapi\Python\ColumnActivityDiagram\sampleinput.txt:/ColumnActivityDiagram/sampleinput.txt  sampleinp -fn "sampleinput.txt" -gn "sampleinput" -mc "19" -ht "8" -yt "yaxis" -xt "xaxis" -min "50" -max "4000" -st "'single column'" -fign "CortialColumn" -a

-v D:\ShababUddin\neocortexapi\Python\ColumnActivityDiagram\sampleinput.txt:/ColumnActivityDiagram/sampleinput.txt


docker build -t 13 .        

docker run 13

docker cp ebd145fb39a7:/ColumnActivityDiagram/A20241231.html A.html

docker cp abc:/ColumnActivityDiagram/A20241231.html A2.html





WORKING COMMAND:

docker run -v D:\ShababUddin\neocortexapi\Python\ColumnActivityDiagram\sampleinput.txt:/ColumnActivityDiagram/sampleinput.txt  sampleinp -fn "sampleinput.txt" -gn "sampleinput" -mc "19" -ht "8" -yt "yaxis" -xt "xaxis" -min "50" -max "4000" -st "'single column'" -fign "CortialColumn" -a

