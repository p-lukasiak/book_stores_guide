import scrapy

class CzytamPlSpider(scrapy.Spider):
   name = "czytam-pl"
   start_urls = [
      'https://czytam.pl/k,ks_741519,Odetchnij-od-miasta-Boguslawska-Aleksandra.html'
   ]

   #def parse(self, response):
   #   filename = 'czytampl-item.html'
   #   with open(filename, 'wb') as f:
   #      f.write(response.body)
   def parse(self, response):
      for li in response.css('li.header-nav-list div div ul li'):
         yield {
            'text': li.css('a::text').extract_first(),
            'url': li.css('a::attr(href)').extract_first()
         }