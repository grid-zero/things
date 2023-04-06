from urllib import request
from bs4 import BeautifulSoup
import re
import os
import urllib

# connect to website and get list of all pdfs
url="https://www.fairwork.gov.au/pay-and-wages/minimum-wages/pay-guides"
response = request.urlopen(url).read()
soup= BeautifulSoup(response, "html.parser")     
links = soup.find_all('a', href=re.compile(r'(.docx)'))


# clean the pdf link names
url_list = []

for el in links:

    #print(el['href'])
    pdfname = el['href']
    spliturl = pdfname.split('=')
    print(spliturl[1])
    url_list.append(spliturl[1])
    #print(url_list)


# download the pdfs to a specified location
for url in url_list:
    #print(url)
    fullfilename = os.path.join(r"C:\Users\azzhu\Downloads\webscrapes", "1")
    #print(fullfilename)
    #request.urlretrieve(url, fullfilename)
    os.system(f'curl "https://api.fairwork.gov.au/capi/v1/api/PayGuide/GetPayGuideDocument" -X POST -H "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:102.0) Gecko/20100101 Firefox/102.0" -H "Accept: application/json" -H "Accept-Language: en-US,en;q=0.5" -H "Accept-Encoding: gzip, deflate, br" -H "Referer: https://services.fairwork.gov.au/" -H "Access-Control-Allow-Origin: https://api.fairwork.gov.au/capi/v1" -H "Access-Control-Allow-Methods: POST" -H "Content-Type: application/json-patch+json" -H "Origin: https://services.fairwork.gov.au" -H "DNT: 1" -H "Connection: keep-alive" -H "Sec-Fetch-Dest: empty" -H "Sec-Fetch-Mode: cors" -H "Sec-Fetch-Site: same-site" --data-raw "{{""fileNameWithExtension"":""{url}""}}" --output {url}')