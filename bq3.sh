wget https://goo.gl/BhphrS
mv BhphrS biopics.csv
# clean data
# slecet box office and year from data
awk -F "," '{print $4 "," $5}' biopics.csv > yearboxoffice.csv
#delete all empty lines and row of title,replace - for 0,get rid of letters
sed '/^$/d' yearboxoffice.csv|tail -n +2|sed 's/-/0/g'|sed '/[a-zA-Z]/d'|sort > temp1.csv

# get data
# calculate the average boxoffice for all  years
awk -F "," '{sum[$1]+=$2}{count[$1]+=1}END{for(year in sum )print year "," sum[year]/count[year]}' temp1.csv|sort >avg.csv


# add title and change format
echo "Year, Average Gross" > title.csv
sed  's/,/<\/th><th>/g' title.csv|sed 's/^/<tr><th>/'|sed 's/$/<\/th><\/tr>/' > title.html

#change format
sed 's/,/<\/td><td>/g' avg.csv|sed 's/^/<tr><td>/'|sed 's/$/<\/td><\/tr>/' > body.html
echo "<html><body><table>" > top.html
echo "</table></body></html>" > bottom.html
# connect file
cat top.html title.html body.html bottom.html > ba3.html
#remove all temporary files
rm avg.csv title.csv title.html body.html top.html bottom.html
rm temp1.csv yearboxoffice.csv
