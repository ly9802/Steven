#download data from website and change name
wget https://goo.gl/BhphrS
mv BhphrS biopics1.csv

# clean data
sed '/^$/d' biopics1.csv > biopics.csv
# produce sql database
python3 csv2sqlite.py --table-name biopics --input biopics.csv --output biopics.sqlite

#get data
sqlite3 biopics.sqlite 'select year_release, avg(box_office) from biopics group by year_release' > temp1.csv
#change format of csv
sed 's/|/,/g' temp1.csv > body.csv

# add title and change format
echo "Year, Average Gross" > title.csv
sed  's/,/<\/th><th>/g' title.csv|sed 's/^/<tr><th>/'|sed 's/$/<\/th><\/tr>/' > title.html

#change format of body
sed 's/,/<\/td><td>/g' body.csv|sed 's/^/<tr><td>/'|sed 's/$/<\/td><\/tr>/' > body.html
echo "<html><body><table>" > top.html
echo "</table></body></html>" > bottom.html
# connect file
cat top.html title.html body.html bottom.html > sa3.html
#remove the temporary files
rm biopics1.csv biopics.csv biopics.sqlite temp1.csv body.csv title.csv title.html body.html top.html bottom.html
