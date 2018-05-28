#this code is used to extract the director name and calculate how many films are produced by him
#this is the assignment of data manipulation
#download data from website and change name
wget https://goo.gl/BhphrS
mv BhphrS biopics1.csv

# clean data
sed '/^$/d' biopics1.csv > biopics.csv
# produce sql database
python3 csv2sqlite.py --table-name biopics --input biopics.csv --output biopics.sqlite
# get data
sqlite3 biopics.sqlite 'select director,count(title) from biopics group by director' > temp1.csv
awk -F "|" '{print $1 "," $2}' temp1.csv|sort >  temp2.csv
# add title
echo "Director name, The number of movies" > title.csv
#connect titel with other files
cat title.csv temp2.csv > sa1.txt
#remove all temporary files 
rm biopics.sqlite title.csv temp1.csv temp2.csv biopics.csv biopics1.csv
