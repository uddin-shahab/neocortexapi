NeoCortex API:
===========================

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

