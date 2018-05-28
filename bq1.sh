# this code is used to extract director name and calculate how many films are produced by him 
wget https://goo.gl/BhphrS
mv BhphrS biopics.csv
# clean data
awk -F "," '{print $1 "," $6}' biopics.csv > filmdirector.csv
# delete all the empty rows and the row of title
sed '/^$/d' filmdirector.csv|tail -n +2 >temp1.csv
 
#get data
awk -F "," '{print $2}' temp1.csv|sort|uniq -c > temp2.csv
awk -F " " '{print $2 "," $1}' temp2.csv > temp3.csv
echo "Director Name, The total number of movies " > title.csv
cat title.csv temp3.csv > ba1.txt
rm temp1.csv temp2.csv temp3.csv title.csv filmdirector.csv 
