# download the orginal data from website and change its name
# this is the assignment of data manipulation, it is used to calculate the box office
wget https://goo.gl/BhphrS
mv BhphrS biopics.csv
# clean data
# slecet box office and gender from data
awk -F "," '{print $13 "," $5}' biopics.csv > genderboxoffice.csv
#delete all empty lines and row of title,replace - for 0
sed '/^$/d' genderboxoffice.csv|tail -n +2|sed 's/-/0/g' > temp1.csv

#get data
grep "Male" temp1.csv > Maleboxoffice.csv
grep "Female" temp1.csv > Femaleboxoffice.csv
# calculate amout for male and fefmale
awk -F "," '{total+=$2}END{print "Male" "," total}' Maleboxoffice.csv > Male.csv
awk -F "," '{total+=$2}END{print "Female" "," total}' Femaleboxoffice.csv > Female.csv
# add title and change format
echo "Gender, Total Amout" > title.csv
sed  's/,/<\/th><th>/g' title.csv|sed 's/^/<tr><th>/'|sed 's/$/<\/th><\/tr>/' > title.html
# connect file
cat Female.csv Male.csv > ba2.csv
#change format
sed 's/,/<\/td><td>/g' ba2.csv|sed 's/^/<tr><td>/'|sed 's/$/<\/td><\/tr>/' > body.html
echo "<html><body><table>" > top.html
echo "</table></body></html>" > bottom.html
# connect file
cat top.html title.html body.html bottom.html > ba2.html
rm genderboxoffice.csv temp1.csv Maleboxoffice.csv Femaleboxoffice.csv Male.csv Female.csv title.csv title.html ba2.csv body.html
rm top.html bottom.html
