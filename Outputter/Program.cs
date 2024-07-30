using System.Text;

byte stx = 0x02;
byte etx = 0x03;
byte id = 0x39;

void ChannelOpenCommand () 
{
    for ( int i = 1; i < 4; i++ ) // Card Number
    {
        for ( int j = 1; j < 9; j++ )
        {
            Console.WriteLine( $"private void OpenCard{i}Channel{j}()" );
            Console.WriteLine( "{" );
            Console.WriteLine( $"   if(ButtonStates{i - 1}[{j - 1}] == buttonStateBrushList[0])" );
            Console.WriteLine( "   {" );
            Console.WriteLine( $"      scModel.SendChannelOpenRequest({i - 1},{j});" );
            Console.WriteLine( $"      ButtonStates{i - 1} [{j - 1}] = buttonStateBrushList [1];" );
            Console.WriteLine( "   }" );
            Console.WriteLine( $"   if(ButtonStates{i - 1}[{j - 1}] == buttonStateBrushList[1])" );
            Console.WriteLine( "   {" );
            Console.WriteLine( $"      scModel.SendChannelCloseRequest({i - 1},{j});" );
            Console.WriteLine( $"      ButtonStates{i - 1} [{j - 1}] = buttonStateBrushList [0];" );
            Console.WriteLine( "   }" );
            Console.WriteLine( "}" );
        }
    }
}

void CardOutsPrint () 
{
    for ( int cardNumber = 1; cardNumber < 4; cardNumber++ )
    {
        Console.WriteLine($"private int card{cardNumber}Voltage;");
        Console.WriteLine();
        Console.WriteLine($"public int Card{cardNumber}Voltage");
        Console.WriteLine("{");
        Console.WriteLine("   get");
        Console.WriteLine("   {");
        Console.WriteLine($"      return card{cardNumber}Voltage;");
        Console.WriteLine("   }");
        Console.WriteLine("   set");
        Console.WriteLine( "   {" );
        Console.WriteLine( $"       if(card{cardNumber}Voltage != value)" );
        Console.WriteLine(  "       {" );
        Console.WriteLine( $"          card{cardNumber}Voltage = value;" );
        Console.WriteLine( $"          OnPropertyChanged(nameof(Card{cardNumber}Voltage));" );
        Console.WriteLine(  "       }" );
        Console.WriteLine( "   }" );
        Console.WriteLine( "}" );
        for ( int channelNumber = 1; channelNumber < 9; channelNumber++ )
        {
            Console.WriteLine( $"private int card{cardNumber}Channel{channelNumber}Current;" );
            Console.WriteLine();
            Console.WriteLine( $"public int Card{cardNumber}Channel{channelNumber}Current" );
            Console.WriteLine( "{" );
            Console.WriteLine( "   get" );
            Console.WriteLine( "   {" );
            Console.WriteLine( $"      return card{cardNumber}Channel{channelNumber}Current;" );
            Console.WriteLine( "   }" );
            Console.WriteLine( "   set" );
            Console.WriteLine( "   {" );
            Console.WriteLine( $"       if(card{cardNumber}Channel{channelNumber}Current != value)" );
            Console.WriteLine( "       {" );
            Console.WriteLine( $"          card{cardNumber}Channel{channelNumber}Current = value;" );
            Console.WriteLine( $"          OnPropertyChanged(nameof(Card{cardNumber}Channel{channelNumber}Current));" );
            Console.WriteLine( "       }" );
            Console.WriteLine( "   }" );
            Console.WriteLine( "}" );
        }
    }
}

void CardsOutDataManupulation () 
{
    int card1ChannelCount = 1;
    int card2ChannelCount = 1;
    int card3ChannelCount = 1;
    for ( int dataIndex = 0; dataIndex < 108;)
    {
        if ( dataIndex <= 35 ) // Card1
        {
            if ( dataIndex == 0 ) // First enterance
            {
                Console.WriteLine($"Card1Voltage = Calculate4byteInput( dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}] );" );
            }
            else
            {
                Console.WriteLine($"Card1Channel{card1ChannelCount++}Current = Calculate4byteInput( dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}] );" );
            }
        }
        else if (35 < dataIndex && dataIndex <= 71 ) // Card2
        {
            if ( dataIndex == 36 ) // First enterance
            {
                Console.WriteLine( $"Card2Voltage = Calculate4byteInput( dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}] );" );
            }
            else
            {
                Console.WriteLine( $"Card2Channel{card2ChannelCount++}Current = Calculate4byteInput( dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}] );" );
            }
        }
        else if (71 < dataIndex) // Card2
        {
            if ( dataIndex == 72 ) // First enterance
            {
                Console.WriteLine( $"Card3Voltage = Calculate4byteInput( dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}] );" );
            }
            else
            {
                Console.WriteLine( $"Card3Channel{card3ChannelCount++}Current = Calculate4byteInput( dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}], dataToBeChecked [{dataIndex++}] );" );
            }
        }
    }
}

void CardChannelCommunicationActivePrint ()
{
    for ( int cardNumber = 1; cardNumber < 4; cardNumber++ )
    {
        Console.WriteLine( $"private bool card{cardNumber}IsActive;" );
        Console.WriteLine();
        Console.WriteLine( $"public bool Card{cardNumber}IsActive" );
        Console.WriteLine( "{" );
        Console.WriteLine( "   get" );
        Console.WriteLine( "   {" );
        Console.WriteLine( $"      return card{cardNumber}IsActive;" );
        Console.WriteLine( "   }" );
        Console.WriteLine( "   set" );
        Console.WriteLine( "   {" );
        Console.WriteLine( $"       if(card{cardNumber}IsActive != value)" );
        Console.WriteLine( "       {" );
        Console.WriteLine( $"          card{cardNumber}IsActive = value;" );
        Console.WriteLine( $"          OnPropertyChanged(nameof(Card{cardNumber}IsActive));" );
        Console.WriteLine( "       }" );
        Console.WriteLine( "   }" );
        Console.WriteLine( "}" );
        for ( int channelNumber = 1; channelNumber < 9; channelNumber++ )
        {
            Console.WriteLine( $"private bool card{cardNumber}Channel{channelNumber}IsActive;" );
            Console.WriteLine();
            Console.WriteLine( $"public bool Card{cardNumber}Channel{channelNumber}IsActive" );
            Console.WriteLine( "{" );
            Console.WriteLine( "   get" );
            Console.WriteLine( "   {" );
            Console.WriteLine( $"      return card{cardNumber}Channel{channelNumber}IsActive;" );
            Console.WriteLine( "   }" );
            Console.WriteLine( "   set" );
            Console.WriteLine( "   {" );
            Console.WriteLine( $"       if(card{cardNumber}Channel{channelNumber}IsActive != value)" );
            Console.WriteLine( "       {" );
            Console.WriteLine( $"          card{cardNumber}Channel{channelNumber}IsActive = value;" );
            Console.WriteLine( $"          OnPropertyChanged(nameof(Card{cardNumber}Channel{channelNumber}IsActive));" );
            Console.WriteLine( "       }" );
            Console.WriteLine( "   }" );
            Console.WriteLine( "}" );
        }
    }
}

void CardChannelErrorPrint ()
{
    for ( int cardNumber = 1; cardNumber < 4; cardNumber++ )
    {
        for ( int channelNumber = 1; channelNumber < 9; channelNumber++ )
        {
            Console.WriteLine( $"private int card{cardNumber}Channel{channelNumber}IsOk;" );
            Console.WriteLine();
            Console.WriteLine( $"public int Card{cardNumber}Channel{channelNumber}IsOk" );
            Console.WriteLine( "{" );
            Console.WriteLine( "   get" );
            Console.WriteLine( "   {" );
            Console.WriteLine( $"      return card{cardNumber}Channel{channelNumber}IsOk;" );
            Console.WriteLine( "   }" );
            Console.WriteLine( "   set" );
            Console.WriteLine( "   {" );
            Console.WriteLine( $"       if(card{cardNumber}Channel{channelNumber}IsOk != value)" );
            Console.WriteLine( "       {" );
            Console.WriteLine( $"          card{cardNumber}Channel{channelNumber}IsOk = value;" );
            Console.WriteLine( $"          OnPropertyChanged(nameof(Card{cardNumber}Channel{channelNumber}IsOk));" );
            Console.WriteLine( "       }" );
            Console.WriteLine( "   }" );
            Console.WriteLine( "}" );
            Console.WriteLine();
        }
    }
}

void CardChannelErrorConditionCheckPrint () 
{
    int dataIndex1 = 0;
    int dataIndex2 = 0;
    for ( int cardNumber = 1; cardNumber < 4; cardNumber++ )
    {
        for ( int channelNumber = 1; channelNumber < 9; channelNumber++ )
        {
            Console.WriteLine( $"Card{cardNumber}Channel{channelNumber}IsActive = dataToBeChecked[{dataIndex1++}] != 128 && dataToBeChecked[{dataIndex1++}] != 128;" );
            Console.WriteLine( $"Card{cardNumber}Channel{channelNumber}IsOk = CalculateDataLength( dataToBeChecked [{dataIndex2++}], dataToBeChecked [{dataIndex2++}] );" );
        }
    }
}

void SerialViewModelCardChannelOkPrint () 
{
    for ( int cardNumber = 1; cardNumber < 4; cardNumber++ )
    {
        for ( int channelNumber = 1; channelNumber < 9; channelNumber++ )
        {
            Console.WriteLine($"else if ( e.PropertyName == \"Card{cardNumber}Channel{channelNumber}IsOk\")");
            Console.WriteLine("{");
            Console.WriteLine($"   this.Card{cardNumber}Channel{channelNumber}IsOk = scModel.Card{cardNumber}Channel{channelNumber}IsOk;" );
            Console.WriteLine($"   App.Current.Dispatcher.Invoke( () => CheckForUIUpdates( \"Card{cardNumber}Channel{channelNumber}IsOkChanged\", DateTime.Now, Card{cardNumber}Channel{channelNumber}IsOk.ToString() ) );" );
            Console.WriteLine("}" );
        }
    }
}

void SerialViewModelUpdateUICheckConditionsPrint () 
{
    int dataIndex = 0;
    int constantIndexAdd = 1;
    for ( int cardNumber = 1; cardNumber < 4; cardNumber++ )
    {
        for ( int channelNumber = 1; channelNumber < 9; channelNumber++ )
        {
            Console.WriteLine( $"else if (updateType == \"Card{cardNumber}Channel{channelNumber}IsOkChanged\")\r\n            {{\r\n                /* 0- Ok\r\n                 * 1- shortCircuit \r\n                 * 2- overCurrent \r\n                 * 3- shortCircuit + overCurrent\r\n                 * 4- voltageError\r\n                 * 5- shortCircuit + voltageError \r\n                 * 6- overCurrent + voltageError\r\n                 * 7- shortCircuit + overCurrent + voltageError\r\n                 * 128- No communication \r\n                 */\r\n                switch ( data )\r\n                {{\r\n                    case \"0\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [1];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [1];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [1];\r\n                        break;\r\n                    case \"1\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [0];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [1];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [1];\r\n                        break;\r\n                    case \"2\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [1];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [0];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [1];\r\n                        break;\r\n                    case \"3\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [0];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [0];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [1];\r\n                        break;\r\n                    case \"4\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [1];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [1];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [0];\r\n                        break;\r\n                    case \"5\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [0];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [1];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [0];\r\n                        break;\r\n                    case \"6\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [1];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [0];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [0];\r\n                        break;\r\n                    case \"7\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [0];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [0];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [0];\r\n                        break;\r\n                    case \"128\":\r\n                        ErrorStatusShortCircuitList{dataIndex} [{channelNumber-1}] = errorStateBrushList [3];\r\n                        ErrorStatusList{dataIndex}1 [{channelNumber-1}] = errorStateBrushList [3];\r\n                        ErrorStatusList{dataIndex} [{channelNumber-1}] = errorStateBrushList [3];\r\n                        break;\r\n                    default:\r\n                        break;\r\n                }}\r\n            }}" );
        }
        dataIndex++;
    }
}

void SampleCommunicationPrint () 
{
    Console.WriteLine("Analog cevap");
    StringBuilder builder = new StringBuilder();
    byte result = (byte)(stx ^ id ^ 0xCB ^ 0x33 ^ 0x30);
    builder.Append("0239CB3330");
    for ( int i = 0; i < 2; i++ )
    {
        
    }
    byte [] temp = Encoding.ASCII.GetBytes( result.ToString( "X2" ) );
    string one = temp [0].ToString();
    string two = temp [1].ToString();
    builder.Append(one);
    builder.Append(two);
    builder.Append("03");
    Console.WriteLine(builder.ToString());
}

bool test = true;
bool test1 = false;

Console.WriteLine(test.ToString() + " " + test1.ToString());
