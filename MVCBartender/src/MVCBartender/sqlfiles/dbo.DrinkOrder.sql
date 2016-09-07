CREATE TABLE [dbo].[DrinkOrder] (
    [ID]            INT             IDENTITY (1, 1) NOT NULL,
    [drinkInvID]    INT             NULL,
    [drinkQuant]    INT             NULL,
    [orderComplete] BIT             NULL,
    [totalPrice]    DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_DrinkOrder] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_DrinkOrder_drinkInv_drinkInvID] FOREIGN KEY ([drinkInvID]) REFERENCES [dbo].[drinkInv] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_DrinkOrder_drinkInvID]
    ON [dbo].[DrinkOrder]([drinkInvID] ASC);

