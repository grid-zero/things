from PyPDF2 import PdfReader

reader = PdfReader("aboriginal-community-controlled-health-services-award-ma000115-pay-guide.pdf")
number_of_pages = len(reader.pages)
page = reader.pages[0]
text = page.extract_text()
if text.
print(text)