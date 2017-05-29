import { SimpleOnlineShop.ClientPage } from './app.po';

describe('simple-online-shop.client App', () => {
  let page: SimpleOnlineShop.ClientPage;

  beforeEach(() => {
    page = new SimpleOnlineShop.ClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
